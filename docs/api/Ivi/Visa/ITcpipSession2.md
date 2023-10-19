English | 日本語

# ITcpipSession2 Interface

## Definition
Namespace:[Ivi.Visa](../Visa.md)<BR>
Assembly:Ivi.Visa.dll<BR>
Inheritance:[System.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) -> [Ivi.Visa.IVisaSession](IVisaSession.md) -> [Ivi.Visa.IMessageBasedSession](IMessageBasedSession.md) -> [Ivi.Visa.ITcpipSession](Ivi.Visa.ITcpipSession.md) -> **Ivi.Visa.ITcpipSession2**

## Properties

|Property Name|
|---|
|[EncryptionEnabled](#EncryptionEnabled-Property)|
|[SaslMechanism](#SaslMechanism-Property)|
|[ServerCertificate](#ServerCertificate-Property)|
|[System.DateTime ServerCertificateExpirationDate](#System.DateTime-ServerCertificateExpirationDate-Property)|
|[ServerCertificateIsPerpetual](#ServerCertificateIsPerpetual-Property)|
|[ServerCertificateIssuerName](#ServerCertificateIssuerName-Property)|
|[ServerCertificateSubjectName](#ServerCertificateSubjectName-Property)|
|[TlsCipherSuite](#TlsCipherSuitev-Property)|

## EncryptionEnabled Property
```C#
Boolean EncryptionEnabled { get; set; }
```
## SaslMechanism Property
```C#
String SaslMechanism { get; }
```
## ServerCertificate Property
```C#
String ServerCertificate { get; }
```
## ServerCertificateExpirationDate Property
```C#
System.DateTime ServerCertificateExpirationDate { get; }
```
## ServerCertificateIsPerpetual Property
```C#
Boolean ServerCertificateIsPerpetual { get; }
```
## ServerCertificateIssuerName Property
```C#
String ServerCertificateIssuerName { get; }
```
## ServerCertificateSubjectName Property
```C#
String ServerCertificateSubjectName { get; }
```
## TlsCipherSuite Property
```C#
String TlsCipherSuite { get; }
```
