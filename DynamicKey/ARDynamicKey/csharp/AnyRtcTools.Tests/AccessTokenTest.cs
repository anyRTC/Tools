using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyRtcTools.Tests
{
    [TestClass]
    public class AccessTokenTest
    {
        private string appID = "970CA35de60c44645bbae8a215061b33";
        private string appCertificate = "5CFd2fd1755d40ecb72977518be15d3b";
        private string channelName = "7d72365eb983485397e3e3f9d460bdda";
        private string uid = "2882341273";
        private int expireTimestamp = 1446455471;
        private int salt = 1;
        private int ts = 1111111;

        [TestMethod]
        public void TestBuild()
        {
            var expected = "006970CA35de60c44645bbae8a215061b33IACV0fZUBw+72cVoL9eyGGh3Q6Poi8bgjwVLnyKSJyOXR7dIfRBXoFHlEAABAAAAR/QQAAEAAQCvKDdW";

            var key = new AccessToken(appID, appCertificate, channelName, uid);
            key._salt = salt;
            key._ts = ts;
            key.AddPrivilege(AccessToken.kJoinChannel, expireTimestamp);

            var result = key.Build();

            Assert.AreEqual(expected, result);

            // test uid = 0
            expected = "006970CA35de60c44645bbae8a215061b33IACw1o7htY6ISdNRtku3p9tjTPi0jCKf9t49UHJhzCmL6bdIfRAAAAAAEAABAAAAR/QQAAEAAQCvKDdW";

            var uid_zero = "";
            key = new AccessToken(appID, appCertificate, channelName, uid_zero);
            key._salt = salt;
            key._ts = ts;
            key.AddPrivilege(AccessToken.kJoinChannel, expireTimestamp);

            result = key.Build();
            Assert.AreEqual(expected, result);
        }
    }
}
