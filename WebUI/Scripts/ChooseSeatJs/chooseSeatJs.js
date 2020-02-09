//��ȡ�������������ֵ
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}
var chipInfoID = GetQueryString("ChipInfoID");
var officeID = GetQueryString("OfficeID");
var Language = GetQueryString("Language");
if (Language == 'english') Language = "Ӣ��";
else Language = "����";
var Money = GetQueryString("Money");
//��ʼ������
var vm = new Vue({
    el: "#chooseSeat_section",
    data: {
        List: [{
            SeatID: "",
            OfficeID: "",
            IsSeat: ""
        }],
        konglie1: 5,
        konglie2: 12,
        SeatIDarray: []
    },
    mounted() {
        this.loadMovieInfo(),
            this.loatSeat(),
            this.loadCinema(),
            this.loadOffice();
    },
    methods: {
        sureChooseSeat() {
            $.ajax({
                type: "Post",
                async: false,
                dataType: "json",
                //url: "ChooseSeat.aspx?Method=sureChooseSeat&SeatIDarray=" + vm.SeatIDarray,
                url: "ChooseSeat.aspx?Method=sureChooseSeat",
                data: {
                    'SeatIDarray': JSON.stringify(vm.SeatIDarray),
                    ChipInfoID: chipInfoID,
                    Money: Money,
                    officeID: officeID
                },
                success: function (data) {
                    alert("ѡ���ɹ�!");
                    setTimeout(function () {
                        window.location.href = "OrderPay.aspx?OrderID=" + data.OrderID;
                    }, 1000)
                },
                Error: function () {
                    alert("����ʧ��!");
                }
            })
        },
        loatSeat: function () {
            $.ajax({
                type: "Post",
                url: "ChooseSeat.aspx?Method=loadSeatInfo",
                data: {
                    OfficeID: officeID,
                    chipInfoID: chipInfoID
                },
                success: function (data) {
                    var jsondata = JSON.parse(data);
                    //alert("ת���ɹ�");
                    vm.List = jsondata;
                    //alert(vm.List);
                    $.each(jsondata,
                        function (index, value) {
                            if (value.IsSeat == 0 && value.SeatID % 160 % 16 < 8) {
                                this.konglie1 = value.SeatID % 160 % 16;
                                //alert(this.konglie1);
                            } else if (value.IsSeat == 0 && value.SeatID % 160 %
                                16 > 8) {
                                this.konglie2 = value.SeatID % 160 % 16;
                                //alert(this.konglie2);
                            }
                        })
                }
            });
        },
        loadMovieInfo: function () {
            $.ajax({
                type: "Post",
                async: false,
                url: "ChooseSeat.aspx?Method=loadMovieInfo",
                data: {
                    ChipInfoID: chipInfoID
                },
                success: function (data) {
                    var jsondata = JSON.parse(data);
                    //alert("ת���ɹ�");
                    $('.chooseSeat_section_body_right_MovieInfo_topImg').children('img').attr("src", "images/MovieCover/" + jsondata.MovieCover);
                    $('.chooseSeat_section_body_right_MovieInfo_topText_title').html(jsondata.MovieName);
                    $('.chooseSeat_section_body_right_MovieInfo_topText_type').html("���ͣ�" + jsondata.MovieType);
                    $('.chooseSeat_section_body_right_MovieInfo_topText_des').html("ʱ����" + jsondata.MovieDuration + "����");
                    $('.chooseSeat_section_body_right_MovieInfo_text_banben').html(Language);
                    $('.chooseSeat_section_body_right_MovieInfo_text_piaojia').html(Money);
                }
            });
        },
        loadCinema: function () {
            $.ajax({
                type: "Post",
                async: false,
                url: "ChooseSeat.aspx?Method=loadCinema",
                data: {
                    ChipInfoID: chipInfoID
                },
                success: function (data) {
                    var jsondata = JSON.parse(data);
                    $('.chooseSeat_section_body_right_MovieInfo_text_yingyuan').html(jsondata.CinemaName);
                    $('.chooseSeat_section_body_right_MovieInfo_text_changci').html(jsondata.CinemaName);
                }
            });
        }, loadOffice: function () {
            $.ajax({
                type: "Post",
                async: false,
                url: "ChooseSeat.aspx?Method=loadOffice",
                data: {
                    ChipInfoID: chipInfoID
                },
                success: function (data) {
                    var jsondata = JSON.parse(data);
                    $('.chooseSeat_section_body_right_MovieInfo_text_yingting').html(jsondata.OfficeName);
                }
            });
        },
        changeSeatBg(event, SeatID) {
            /*5��������У����У�Ҳ���Ƿ���λ��*/
            /*12�����ʮ���У����У�Ҳ���Ƿ���λ��*/
            //alert(konglie1);
            //alert(konglie2);
            var i = SeatID;
            var zuowei = ""
            if (i % 160 % 16 < vm.konglie1) {
                //alert("1"+SeatID);
                zuowei = (parseInt(SeatID % 160 / 16) + 1) + "��" + (i % 160 % 16) + "��";
                if (i % 160 % 16 == 0) {
                    zuowei = (parseInt(SeatID % 160 / 16)) + "��" + "14" + "��";
                }
                //alert(zuowei);
            } else if (i % 160 % 16 < vm.konglie2) {
                //alert("2"+SeatID);
                zuowei = (parseInt(SeatID % 160 / 16) + 1) + "��" + (i % 160 % 16 - 1) + "��";
                //alert(zuowei);
            } else if (i % 160 % 16 < 16) {
                //alert("3"+SeatID);
                zuowei = (parseInt(SeatID % 160 / 16) + 1) + "��" + (i % 160 % 16 - 2) + "��";
                //alert(zuowei);
            }
            var el = event.currentTarget;
            //alert("��ǰ��������ݣ�" + el.src);
            var host = "https://" + window.location.host;

            var piao = $('.seatCheckInfo').html();
            if (el.src == host + "/images/ChooseSeatImg/seat.png") {
                el.src = host + "/images/ChooseSeatImg/seatChecked.png";
                piao = piao + "  " + zuowei;
                $('.seatCheckInfo').html(piao);
                vm.SeatIDarray.push(SeatID);
            } else if (el.src == host + "/images/ChooseSeatImg/seatChecked.png") {
                el.src = host + "/images/ChooseSeatImg/seat.png";
                piao = piao.replace(zuowei, "");
                $('.seatCheckInfo').html(piao);
                //ɾ��������ָ��Ԫ��
                vm.SeatIDarray.splice($.inArray(SeatID, vm.SeatIDarray), 1);
            }
        }
    }
})

var timer = setInterval(function () {
    if (vm.SeatIDarray != null) {
        $('#Sum').html("��" + (vm.SeatIDarray.length * Money));
    }
}, 500);