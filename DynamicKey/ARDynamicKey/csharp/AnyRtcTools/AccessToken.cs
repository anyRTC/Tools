using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AnyRtcTools
{
    public class AccessToken
    {
        public const ushort kJoinChannel = 1;
        public const ushort kPublishAudioStream = 2;
        public const ushort kPublishVideoStream = 3;
        public const ushort kPublishDataStream = 4;
        public const ushort kPublishAudiocdn = 5;
        public const ushort kPublishVideoCdn = 6;
        public const ushort kRequestPublishAudioStream = 7;
        public const ushort kRequestPublishVideoStream = 8;
        public const ushort kRequestPublishDataStream = 9;
        public const ushort kInvitePublishAudioStream = 10;
        public const ushort kInvitePublishVideoStream = 11;
        public const ushort kInvitePublishDataStream = 12;
        public const ushort kAdministrateChannel = 101;
        public const ushort kRtmLogin = 1000;

        public const int VERSION_LENGTH = 3;
        public const int APP_ID_LENGTH = 32;

        private readonly string _appID;
        private readonly string _appCertificate;
        private readonly string _channelName;
        private readonly string _uid;
        public int _ts;
        public int _salt;
        private SortedDictionary<ushort, int> _messages;

        public AccessToken(string appID, string appCertificate, string channelName, string uid)
        {
            _appID = appID;
            _appCertificate = appCertificate;
            _channelName = channelName;
            _uid = uid;

            _ts = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds) + 24 * 3600;
            var random = new Random();
            _salt = random.Next(1, 99999999);
        }

        public void AddPrivilege(ushort privilege, int expireTimestamp)
        {
            if (_messages == null)
            {
                _messages = new SortedDictionary<ushort, int>();
            }

            _messages.Add(privilege, expireTimestamp);
        }

        public string Build()
        {
            if (_messages == null)
            {
                throw new Exception("Please specify some privileges first.");
            }

            var m = BitConverter.GetBytes(_salt)
                .Concat(BitConverter.GetBytes(_ts))
                .Concat(PackMapUint32(_messages));

            var val = Encoding.UTF8.GetBytes(_appID)
                .Concat(Encoding.UTF8.GetBytes(_channelName))
                .Concat(Encoding.UTF8.GetBytes(_uid))
                .Concat(m).ToArray();

            HMACSHA256 hmacSha256 = new HMACSHA256(Encoding.UTF8.GetBytes(_appCertificate));
            var signature = hmacSha256.ComputeHash(val);

            var crc32 = new CRC32Cls();
            var crc_channel_name = crc32.GetCRC32Str(_channelName) & 0xffffffff;
            var crc_uid = crc32.GetCRC32Str(_uid) & 0xffffffff;

            var content = PackString(signature)
                            .Concat(BitConverter.GetBytes(crc_channel_name))
                            .Concat(BitConverter.GetBytes(crc_uid))
                            .Concat(PackString(m.ToArray())).ToArray();

            return $"006{_appID}{Convert.ToBase64String(content)}";
        }

        private static byte[] PackString(byte[] strBytes)
        {
            return BitConverter.GetBytes((ushort)(strBytes.Length))
                .Concat(strBytes).ToArray();
        }

        private static byte[] PackMapUint32(SortedDictionary<ushort, int> ms)
        {
            var m = BitConverter.GetBytes((ushort)(ms.Count));
            IEnumerable<byte> ret = m.ToList();
            foreach (var kvp in ms)
            {
                ret = ret.Concat(BitConverter.GetBytes(kvp.Key))
                    .Concat(BitConverter.GetBytes(kvp.Value));
            }
            return ret.ToArray();
        }
    }
}
