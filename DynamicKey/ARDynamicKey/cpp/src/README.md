- **RtcTokenBuilder.h**: Source code for generating a token for the following SDKs:

> - anyRTC Native SDK V4.0+

> - anyRTC Web SDK V4.0+

> The anyRTC RTSA SDK supports joining multiple channels. If you join multiple channels at the same time, then you MUST generate a specific token for each channel you join. 

- **RtmTokenBuilder.h**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.h**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.h** and **RtmTokenBuilder.h** are a wrapper of **AccessToken.h** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.h** for generating an RTC token or **RtmTokenBuilder.h** for an RTM token.
