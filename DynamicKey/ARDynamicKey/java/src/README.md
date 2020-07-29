- **RtcTokenBuilder.java**: Source code for generating a token for the following SDKs:

> - anyRTC Native SDK v4.0+

> - anyRTC Web SDK v4.0+

- **RtmTokenBuilder.java**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.java**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.java** and **RtmTokenBuilder.java** are a wrapper of **AccessToken.java** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.java** for generating an RTC token or **RtmTokenBuilder.java** for an RTM token.
