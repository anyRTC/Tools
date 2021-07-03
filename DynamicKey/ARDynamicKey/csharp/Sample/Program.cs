using AnyRtcTools;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var appID = "970CA35de60c44645bbae8a215061b33";
            var appCertificate = "5CFd2fd1755d40ecb72977518be15d3b";
            var channelName = "7d72365eb983485397e3e3f9d460bdda";
            var userAccount = "2882341273";

            var expireTimeInSeconds = 3600;
            var currentTimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var privilegeExpiredTs = (int)currentTimestamp + expireTimeInSeconds;

            var token = new AccessToken(appID, appCertificate, channelName, userAccount);
            token.AddPrivilege(AccessToken.kJoinChannel, privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishVideoStream, privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishAudioStream, privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishDataStream, privilegeExpiredTs);

            Console.WriteLine(token.Build());

            Console.ReadLine();
        }
    }
}
