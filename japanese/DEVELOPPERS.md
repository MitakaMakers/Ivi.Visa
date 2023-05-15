# Memo for Contributes

## Development tools & enviroment
マイクロソフト社製の無償ツールを標準開発環境とします。
- OS：Windows 11
- コンパイラ：Net 6 SDK(C#7)
  - xunit
  - coverlet
- テキストエディタ：Visual Studio Code
  - Japanese Language Pack for Visual Studio Code
  - Markdown Preview Mermaid Support
  - Mermaid MArkdown Syntax Highlighting
- デバッガ：C# extension for Visual Studio Code
- API 設計文書生成ツール：doxygen
- UML 設計図生成ツール：Mermeid
- 構成管理ツール：Git for Windows
  - TortoiseGit
- リポジトリ：GitHub
- CI/CD：GitHub Actions

## Test Quality
- Github Actions を使って、Win, Linux, ホスト上でビルドを確認します
- テストでは xUnit を使って動作を確認します。
- テストカバレッジは正常動作パスのカバレッジ 100%、異常動作パスのカバレッジ0%をリリース指標とします。
  - https://zenn.dev/shimat/articles/03ad92427cbed6

## Source code Quality
- クラスと関数と変数の命名について 各種規格が定義している用語を尊重します。
- その他のソースコードの記法について C# コーディングガイドを尊重します。
  - [Documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
  - [C# Language Specification annex on documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
- １関数あたりのサイクロマティック複雑度10未満を目指します。
  - https://devblogs.microsoft.com/dotnet/automate-code-metrics-and-class-diagrams-with-github-actions/
- １ファイルの行数は2000行未満を目指します。逆に50行未満の短すぎるファイルは統合します。
- 初学者がソースコードを理解しやすいよう、オブジェクト指向ではなく手続き指向で表記します。
- C# 固有のや珍しい表記法は使いません（C99 / Java 2 程度を想定）
- コールバック処理・非同期処理は使いません。
- コードの行数を短くして簡潔に記述するより、多少冗長でも関数の呼び出し回数が少なくなる記法を優先します。

## Domument Quality
説明は簡潔で1ページを2000文字以内にします。

## ToDo
- Support RS232
  - [System.IO.Ports](https://www.nuget.org/packages/System.IO.Ports/)
  - [Null-modem emulator](https://sourceforge.net/projects/com0com/)
- Support USBTMC and USB raw
  - [Usb.Net](https://www.nuget.org/packages/Usb.Net/)
  - [LibUsbDotNet](https://www.nuget.org/packages/LibUsbDotNet/3.0.63-alpha)
- Support GPIB
  - [Linux GPIB(C)](hhttps://sourceforge.net/projects/linux-gpib/)
- Support C library interface
  - [DllExport](https://github.com/3F/DllExport)
- Support Native AOT compile
  - [Natvive AOT](https://learn.microsoft.com/ja-jp/dotnet/core/deploying/native-aot/)