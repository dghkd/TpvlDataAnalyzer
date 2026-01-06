# TpvlDataAnalyzer
台灣職業排球聯盟球員數據統計分析  
數據來源為 台灣職業排球聯盟網站->戰績->球員數據(https://www.tpvl.tw/player/player-ranking)  

![](https://raw.githubusercontent.com/dghkd/TpvlDataAnalyzer/main/preview1.png)

操作方法:
1. 左上角點擊讀取
2. 等待數據載入並顯示於右方
3. 點擊篩選器按鈕，依據需求勾選球員

## 程式方法  
1. 訪問台灣職業排球聯盟球員數據網頁 https://www.tpvl.tw/player/player-ranking
2. 從HTML內容中解析出"__NEXT_DATA__"的Json資料
3. 從Json資料解析出球員數據
4. 計算數據並排序球員列表

## 開發環境
1. Visual Studio Community 2022 版本 17.14.4
2. WPF .Net 8.0 
