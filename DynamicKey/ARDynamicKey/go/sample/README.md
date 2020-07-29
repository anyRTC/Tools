- **RtcTokenBuilder.go**: Source code for generating a token for the following SDKs:
  
> - anyRTC Native SDK v4.0+

> - anyRTC Web SDK v4.0+

> The anyRTC RTSA SDK supports joining multiple channels. If you join multiple channels at the same time, then you MUST generate a specific token for each channel you join. 

- **RtmTokenBuilder.go**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.go**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.go** and **RtmTokenBuilder.go** are a wrapper of **AccessToken.go** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.go** for generating an RTC token or **RtmTokenBuilder.go** for an RTM token.
