using System.Text;

namespace AnyRtcTools
{
    class CRC32Cls
    {
        /*
         * 
         * author: uusystem
         * blog url:  https://www.cnblogs.com/tianjifa/p/9216985.html
         * 
         */
        protected uint[] Crc32Table;
        //生成CRC32码表
        public void GetCRC32Table()
        {
            uint Crc;
            Crc32Table = new uint[256];
            int i, j;
            for (i = 0; i < 256; i++)
            {
                Crc = (uint)i;
                for (j = 8; j > 0; j--)
                {
                    if ((Crc & 1) == 1)
                        Crc = (Crc >> 1) ^ 0xEDB88320;
                    else
                        Crc >>= 1;
                }
                Crc32Table[i] = Crc;
            }
        }

        //获取字符串的CRC32校验值
        public uint GetCRC32Str(string sInputString)
        {
            //生成码表
            GetCRC32Table();
            byte[] buffer = Encoding.UTF8.GetBytes(sInputString);
            uint value = 0xffffffff;
            int len = buffer.Length;
            for (int i = 0; i < len; i++)
            {
                value = (value >> 8) ^ Crc32Table[(value & 0xFF) ^ buffer[i]];
            }
            return value ^ 0xffffffff;
        }
    }
}
