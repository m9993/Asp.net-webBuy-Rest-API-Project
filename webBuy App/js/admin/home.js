$(()=>{



    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('adminWithdrawedMoney').innerHTML = JSON.parse(this.responseText) + " $";
        }
    };
    xmlhttp.open("GET", "http://localhost:59162/api/admin/GetAdminWithdrawedMoney", true);
    xmlhttp.send();







    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('sellerWithdrawedMoney').innerHTML = JSON.parse(this.responseText) + " $";
        }
    };
    xmlhttp.open("GET", "http://localhost:59162/api/admin/GetSellerWithdrawedMoney", true);
    xmlhttp.send();







    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('AvailableBalanceInAllShops').innerHTML = JSON.parse(this.responseText) + " $";
        }
    };
    xmlhttp.open("GET", "http://localhost:59162/api/admin/AvailableBalanceInAllShops", true);
    xmlhttp.send();







    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('totalComission').innerHTML = JSON.parse(this.responseText) + " $";
        }
    };
    xmlhttp.open("GET", "http://localhost:59162/api/admin/GetTotalComission", true);
    xmlhttp.send();







    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var sumTotalInWeek = JSON.parse(this.responseText);

            var days = [];
            const today = new Date()
            const yesterday = new Date(today)
            days.push(today.toDateString());
            for (var i = 1; i < 7; i++) {
                yesterday.setDate(yesterday.getDate() - 1);
                days.push(yesterday.toDateString());
            }

            //chart
            var ctx = document.getElementById('orderChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: days,
                    datasets: [{
                        label: 'Total Amount of Orders in Last Week',
                        data: sumTotalInWeek,
                        backgroundColor: [
                            'rgba(2, 117, 216, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(2, 117, 216, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 3
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
            //chart

        }
    };
    xmlhttp.open("GET", "http://localhost:59162/api/admin/GetTodaySells", true);
    xmlhttp.send();

});