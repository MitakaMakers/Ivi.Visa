# Memo for Contributes

## Development tools & enviroment
マイクロソフト社製の無償ツールを標準開発環境とします。
- OS：Windows 11
- コンパイラ：Net 6 SDK(C#7)
  - テストライブラリ:xunit
  - coverlet
- テキストエディタ：Visual Studio Code
  - Japanese Language Pack for Visual Studio Code
  - Markdown Preview Mermaid Support
  - Mermaid MArkdown Syntax Highlighting
  - 　コードエディタおよび
  - 　文法チェックやフォーマッタなどの拡張機能、
- デバッガ：C# extension for Visual Studio Code
- 設計文書作成ツール：doxygen
- 設計図作成ツール：Mermeid
- ソースコード管理ツール：Git for Windows
  - TortoiseGit
- リポジトリ：GitHub
- 自動テスト環境：GitHub Actions

## Test Quality
- Github Actions を使って、Win, Linux, ホスト上でビルドを確認します
- テストでは xUnit を使って動作を確認します。
- テストカバレッジは正常動作パスのカバレッジ 100%、異常動作パスのカバレッジ0%をリリース指標とします。
  - https://zenn.dev/shimat/articles/03ad92427cbed6

## Source code Quality
- ソフトウェアの動きを理解しやすくするため異常判定やエラー処理は省略しています。
- パフォーマンスを重視しており、コピーの回数はできるだけ少なくしています
- プログラム初心者がソースコードを理解しやすいよう、オブジェクト指向ではなく手続き指向で表記します。
- コードの行数を短くして簡潔に記述するより、多少冗長でも関数の呼び出し回数が少なくなる記法を優先します。
- C# 固有の珍しい表記法は使いません（C# 2.0 / C99 / Java 2 程度を想定）
- 命名規則は、各種通信仕様が定義している用語を優先します。
- その他のソースコードの記法について C# コーディングガイドを採用します。
  - [Documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
  - [C# Language Specification annex on documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
- １関数あたりのサイクロマティック複雑度10未満を目指します。
  - https://devblogs.microsoft.com/dotnet/automate-code-metrics-and-class-diagrams-with-github-actions/
- １ファイルの行数は2000行未満を目指します。逆に50行未満の短すぎるファイルは統合します。
- コールバック処理・非同期処理は使いません。

## Domument Quality
説明は簡潔で1ページを2000文字以内にします。

## ToDo
- Support RS232
  - [System.IO.Ports](https://www.nuget.org/packages/System.IO.Ports/)
- Support USBTMC
  - [LibUsbDotNet](https://www.nuget.org/packages/LibUsbDotNet/3.0.63-alpha)
  - [emulated USB devices](https://learn.microsoft.com/en-us/windows-hardware/drivers/usbcon/developing-windows-drivers-for-emulated-usb-host-controllers-and-devices)
- Support Native AOT compile
  - [Natvive AOT](https://learn.microsoft.com/ja-jp/dotnet/core/deploying/native-aot/)
- Support GPIB
  - [Linux GPIB(C)](hhttps://sourceforge.net/projects/linux-gpib/)
