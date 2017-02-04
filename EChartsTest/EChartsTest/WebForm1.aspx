<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EChartsTest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="JS/echarts.js"></script>
    <title>ECharts</title>
</head>
<body>
    <div>
    <div id="main" style="width:800px;height:600px"></div>
    </div>
    <script type="text/javascript">
        var mychart = echarts.init(document.getElementById("main"));
        var a = 100;
        var option = {
            title: {
                text: '搞事'
            },
            tooltip:{},
            legend: {
                data: ['次数']
            },
            xAxis: {
                data: ["小明", "小王", "小张", "小徐", "小文"]
            },
            yAxis:{},
            series: [{
                name: '次数',
                type: 'bar',
                data: [a, 23, 12, 32, 55]
            }]
        };
        mychart.setOption(option);
    </script>
</body>
</html>
