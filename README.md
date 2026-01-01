# ConsoleAppStopwatch

C# コンソールアプリで作成した **高精度ストップウォッチ** です。  
キー入力で操作でき、内部実装の違いによる精度差を学習できる構成になっています。

---

## 🎯 概要

このプロジェクトでは、以下の 2 種類のストップウォッチ実装を比較しています。

| バージョン | 実装方式 | 特徴 |
|-----------|---------|------|
| V1 | DateTime.UtcNow | シンプルだがズレが出やすい |
| V2 | System.Diagnostics.Stopwatch | 高精度・実運用向き（完成形） |

現在の `Program.cs` では **V2（Stopwatch ベース）** を使用しています。

---

## ⌨ 操作方法

| キー | 動作 |
|----|----|
| Space | 開始 / 一時停止 |
| Delete / Backspace | リセット |
| Enter | 終了 |

表示形式：  
mm:ss.xx

---

## 📂 ディレクトリ構成

```
ConsoleAppStopwatch/
├─ Program.cs
├─ HighPrecisionStopwatchV1.cs   // DateTime ベース実装
├─ HighPrecisionStopwatchV2.cs   // Stopwatch ベース実装（完成形）
└─ README.md
```

---

## 🧠 実装の考え方

### HighPrecisionStopwatch V1（DateTime ベース）

- `DateTime.UtcNow` の差分で経過時間を計算
- スレッドスリープや描画遅延の影響を受けやすい
- 学習用として「なぜズレるのか」を理解するのに適している

```csharp
var elapsed = (DateTime.UtcNow - _startTime).TotalSeconds;
