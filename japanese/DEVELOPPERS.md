# 開発者向け情報

## 開発環境
マイクロソフト社製の無償ツールを標準開発環境とします。
- OS：Windows 11
- コンパイラ：Net 6 SDK
- テキストエディタ：Visual Studio Code, Japanese Language Pack for Visual Studio Code
- デバッガ：C# extension for Visual Studio Code
- 構成管理ツール：Git for Windows, TortoiseGit
- リポジトリ：GitHub
- CI/CD：GitHub Actions

## 品質目標
- ソースコードの記法について C# コーディングガイドを尊重します。
- Github Actions を使って、Win, Linux, ホスト上でビルドを確認します
- テストでは xUnit を使って動作を確認します。
- テストカバレッジは正常動作パスのカバレッジ 100%、異常動作パスのカバレッジ0%をリリース指標とします。

## 文書目標
説明は簡潔で1ページを2000文字以内にします。

## 将来検討メモ
- RS232 通信に対応する
  - ![System.IO.Ports](https://www.nuget.org/packages/System.IO.Ports/) 
- USB 通信に対応する
  - ![Usb.Net](https://www.nuget.org/packages/Usb.Net/)
  - ![LibUsbDotNet](https://www.nuget.org/packages/LibUsbDotNet/3.0.63-alpha)
