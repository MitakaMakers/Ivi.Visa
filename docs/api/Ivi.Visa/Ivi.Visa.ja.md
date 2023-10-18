[English](Ivi.Visa.md) | 日本語

# Ivi.Visa 名前空間

## この記事の内容

- [クラス](#クラス)
- [インターフェイス](#インターフェイス)
- [イベント](#イベント)
- [列挙型](#列挙型)
- [例外](#例外)

## クラス
|名前|説明|
|---|---|
|[IGpibInterfaceSession](Ivi.Visa.IGpibInterfaceSession.md)|GPIBバス用のINTFCセッションタイプ。
|[IGpibSession](Ivi.Visa.IGpibSession.md)|GPIBデバイス用のINSTRセッションタイプ。|[IMemoryMap](Ivi.Visa.IMemoryMap.md)|レジスタベースデバイス用のメモリマッピングサービスを提供します。
|[IMessageBasedFormattedIO](Ivi.Visa.IMessageBasedFormattedIO.md)|MessageBasedFormattedIOは、呼び出しプログラムが様々な一般的なデータタイプを使用できるようにします。
|[IMessageBasedRawIO](Ivi.Visa.IMessageBasedRawIO.md)|IMessageBasedRawIOを使用すると、呼び出し元のプログラムは、フォーマットやパースなしに、文字列やバイト配列のデータを測定器に送信することができます。
|[IMessageBasedSession](Ivi.Visa.IMessageBasedSession.md)|全てのVISA.NETメッセージベースセッションが派生しなければならないインターフェース。
|[INativeVisaEventArgs](Ivi.Visa.INativeVisaEventArgs.md)|VisaEventArgsクラスは発生するイベントを伝達する。
|[INativeVisaSession](Ivi.Visa.INativeVisaSession.md)|ベンダー固有のC属性やイベントにアクセスできるINativeVisaSessionについてまとめています。
|[IPxiBackplaneSession](Ivi.Visa.IPxiBackplaneSession.md)|PXIバックプレーン用のBACKPLANEセッションタイプ。
|[IPxiMemorySession](Ivi.Visa.IPxiMemorySession.md)|PXIデバイスのMEMACCセッションタイプ。
|[IPxiSession](Ivi.Visa.IPxiSession.md)|PXIデバイス用のINSTRセッションタイプ。
|[IRegisterBasedSession](Ivi.Visa.IRegisterBasedSession.md)|レジスタベースデバイス用のベースセッションタイプ。
|[IResourceManager](Ivi.Visa.IResourceManager.md)|IResourceManagerインターフェイスは指定されたリソースのVISA.NETセッションをインスタンス化するメソッドを提供する。
|[ISerialSession](Ivi.Visa.ISerialSession.md)|シリアル(RS-232)デバイス用のINSTRセッション・タイプ。
|[ITcpipSession](Ivi.Visa.ITcpipSession.md)|LANデバイス用のINSTRセッションタイプ。
|[ITcpipSession2](Ivi.Visa.ITcpipSession2.md)|LANデバイスのINSTRセッションタイプ。
|[ITcpipSocketSession](Ivi.Visa.ITcpipSocketSession.md)|TCPIPデバイス用のSOCKETセッションタイプ。
|[ITcpipSocketSession2](Ivi.Visa.ITcpipSocketSession2.md)|TCPIPデバイス用のSOCKETセッションタイプ。 ITcpipSocketSession.|から派生し、ITcpipSocketSession.|に優先する。
|[ITypeFormatter](Ivi.Visa.ITypeFormatter.md)|ITypeFormatterインターフェイスは、サポートされている.NET型の文字列へのカスタム変換を行うメソッドを提供します。
|[IUsbSession](Ivi.Visa.IUsbSession.md)|USBTMCデバイス用のINSTRセッションタイプ。
|[IVisaAsyncResult](Ivi.Visa.IVisaAsyncResult.md)|非同期I/O操作の結果への参照。
|[IVisaSession](Ivi.Visa.IVisaSession.md)|全てのVISA.NETセッションが派生しなければならないインターフェース。
|[IVxiBackplaneSession](Ivi.Visa.IVxiBackplaneSession.md)|VXIバックプレーン用のBACKPLANEセッション・タイプ。
|[IVxiMemorySession](Ivi.Visa.IVxiMemorySession.md)|VXIデバイスのMEMACCセッションタイプ。
|[IVxiSession](Ivi.Visa.IVxiSession.md)|VXIデバイスのINSTRセッションタイプ。

## イベント
|名前|説明|
|---|---|
|[GpibControllerInChargeEventArgs](Ivi.Visa.GpibControllerInChargeEventArgs.md)|充電中のGPIBコントローラ(CIC)イベントに関する追加データを提供します。
|[PxiInterruptEventArgs](Ivi.Visa.PxiInterruptEventArgs.md)|VXI割り込みイベントに関する追加データを提供します。
|[UsbInterruptEventArgs](Ivi.Visa.UsbInterruptEventArgs.md)|USB割り込みイベントに関する追加データを提供します。
|[VisaEventArgs](Ivi.Visa.VisaEventArgs.md)|VisaEventArgsクラスは、発生したイベントに関する情報を伝達します。
|[VxiSignalProcessorEventArgs](Ivi.Visa.VxiSignalProcessorEventArgs.md)|VXIbusシグナルまたはVXIbus割り込みイベントに関する追加データを提供します。
|[VxiTriggerEventArgs](Ivi.Visa.VxiTriggerEventArgs.md)|VXIトリガイベントに関する追加データを提供します。
|[VxiInterruptEventArgs](Ivi.Visa.VxiInterruptEventArgs.md)|VXI割り込みイベントに関する追加データを提供します。

## 列挙型
|名前|説明|
|---|---|
|AccessMode|リソースへのアクセスを制御するさまざまなメカニズムの列挙。|
|AddressSpace|VXI または PXI デバイスで使用されるバス・アドレス空間を示します。|
|AtnMode|GPIB ATN（ATtentioN）インターフェース・ラインの状態の変更方法を示します。|
|BinaryEncoding|フォーマットされた I/O 操作を示します。|
|ByteOrder|さまざまな VXI 操作で使用されるバイト順序を示します。|
|DataWidth|レジスタ・ベースのデータ転送操作のデータ幅を示す。|
|EventQueueStatus|イベント・キューの現在の状態を示す。|
|EventType|非同期 I/O 操作の結果への参照。|
|GpibAddressedState|GPIB インターフェースが現在トークのためにアドレス指定されているのか、リッスンのためにアドレス指定されているのか、あるいはアドレス指定されていないのかを示します。|
|GpibInstrumentRemoteLocalMode|GPIB INSTR セッションの SendRemoteLocalCommand によって実行される動作を示します。
|GpibInterfaceRemoteLocalMode|GPIB INTFC セッションの SendRemoteLocalCommand が取る動作を示します。
|HardwareInterfaceType|現在のセッションのハードウェア・インターフェースのタイプを示します。|
|IOBuffers|低レベル I/O インターフェースのバッファを示す。|
|IOProtocol|特定のセッションで使用するプロトコルを示す。|
|LineState|ラインがアサートされているかどうか、または状態が不明であるかを示す。|
|NativeVisaAttribute|VISA 属性の定義値に対応する。|
|PxiMemoryType|そのセッションでデバイスが使用するメモリ・タイプ(メモリ・マッ プド又は I/O マップド)を示す。|
|ReadStatus|生の I/O 読み出し操作の成功ステータスを示します。|
|RemoteLocalMode|GPIB、TCPIP、または USB INSTR セッションの SendRemoteLocalCommand で実行されるアクションを示します。|
|ResourceLockState|このセッションに関連するリソースのVISAロックの状態を示す。|
|ResourceOpenStatus|オープン操作の成功ステータスを示す。|
|SerialFlowControlModes|シリアル接続で使用されるフロー制御のタイプを示す。|
|SerialParity|Serialシリアル接続でパリティ検査が使用されているかどうかを示します。|
|SerialStopBitsMode|シリアル・フレームの終了を示すために使用されるストップ・ビットの数を示します。|
|SerialTerminationMethod|シリアルの読み取り/書き込み操作を終了するために使用される方法を示す。|
|StatusByteFlags|IEEE 488.2 ステータスバイトの個々のビットを示す。|
|TriggerLine|VXI または PXI トリガー・ラインを示す。|
|TriggerLines|1 つ以上の VXI トリガ ラインを示します。|
|VxiAccessPrivilege|宛先への書き込み時に高レベルのアクセス操作で使用するアドレス修飾子を示します。|
|VxiCommandMode|VxiCommandMode 列挙型は VISA がコマンドを発行するか、レスポンスを取得するかを示す。|
|VxiDeviceClass|特定のリソースが属する VXI 定義デバイスクラスを示す。|
|VxiTriggerProtocol|VXI トリガがアサートされたときに使用されるトリガ・プロトコルを示します。|
|VxiUtilitySignal|アサートするユーティリティ・バス信号を示します。|

## 例外
|名前|説明|
|---|---|
|IOTimeoutException|VISA.NETのI/Oタイムアウトが発生した。|
|NativeErrorCode|標準エラー・ステータス・コードを含むクラス。|
|NativeVisaException|基礎となるVISAネイティブC実装に関連するエラーが発生した。|
|TypeFormatterException|タイプ・フォーマッタ・エラーが発生した。|
|VisaException|VISA.NETエラーが発生した|

