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

## Source code Quality 目標
- ソースコードの記法について C# コーディングガイドを尊重します。
  - [Documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
  - [C# Language Specification annex on documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
- 1関数あたりのサイクロマティック複雑度30未満を目指します。
  - https://devblogs.microsoft.com/dotnet/automate-code-metrics-and-class-diagrams-with-github-actions/
- 他言語習得者でも理解しやすくするため、C#固有や珍しい表記法は使いません
　（C99 / Java 2 程度を想定）
- ソースコードの処理を読みやすくするため抽象クラスやインタフェースクラス、メソッドのオーバーライド、オーバーロードは使いません
- コールバック処理・非同期処理は使いません。
- 関数の呼び出し回数はできるだけ少なくします。

## Domument Quality
説明は簡潔で1ページを2000文字以内にします。

## ToDo
- Support HISLIP
- Support RawSokcet
- Support RS232
  - [System.IO.Ports](https://www.nuget.org/packages/System.IO.Ports/) 
- Support USBTMC and USB raw
  - [Usb.Net](https://www.nuget.org/packages/Usb.Net/)
  - [LibUsbDotNet](https://www.nuget.org/packages/LibUsbDotNet/3.0.63-alpha)
- Support GPIB
  - [Linux GPIB](hhttps://sourceforge.net/projects/linux-gpib/)
- Support C library interface
  - [DllExport](https://github.com/3F/DllExport)
- Support Native AOT compile
  - [Natvive AOT](https://learn.microsoft.com/ja-jp/dotnet/core/deploying/native-aot/)