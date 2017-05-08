var eventBookingModel = new eventBooking();
var EvetnId = GetParameterByName('EventID');
$(document).ready(function () {

    var ele = document.getElementById("EventCreate");
    ko.applyBindings(eventBookingModel, ele);
    showLocationPicker();
    if (EvetnId) {
        if (EvetnId > 0) {
            eventBookingModel.evetnID(parseInt(EvetnId, 0));
            eventBookingModel.loadEvent();

        }
    }
    $('#startDate').datetimepicker({
        format: 'YYYY/MM/DD'
    });
    $('#startTime').datetimepicker({
        format: 'HH:mm'
    });
    $('#endDate').datetimepicker({
        format: 'YYYY/MM/DD'
    });
    $('#endTime').datetimepicker({
        format: 'HH:mm'
    });

})
function showLocationDetails() {
    $(".location-Picker").hide();
    $(".location-details").css("visibility", "visible");
    $(".location-details").css("height", "auto");
    $(".location-details").css("overflow", "auto");
}
function showLocationPicker(){
    $(".location-Picker").show();

    $(".location-details").css("visibility", "hidden");
    $(".location-details").css("height", "0");
    $(".location-details").css("overflow", "hidden");
}
function eventBooking() {
    var vm = this;
    vm.evetnID = ko.observable();
    vm.title = ko.observable('');
    vm.title.subscribe(function (newValue) {
        document.getElementById('titleVal').innerText = newValue;
    });
    vm.venueName = ko.observable('');
    vm.address = ko.observable('');
    vm.address1 = ko.observable('');
    vm.city = ko.observable('');
    vm.countryCode = ko.observable('');
    vm.postcode = ko.observable('');
    vm.zip = ko.observable('');
    vm.country = ko.observable('');

    //tickets 
    vm.ticketList = ko.observableArray();

    vm.addTicket = function (type) {
        var obj = new Ticket(type);
        vm.ticketList.push(obj);
    }
    //get tickets values
    vm.getTicketData = function () {
        var tktArr = [];
        ko.utils.arrayForEach(vm.ticketList(), function (current) {
            obj = {
                EventTicketID: current.eventTicketID(),
                Type: current.type(),
                Name: current.name(),
                Quantity: current.quantity(),
                Price: current.price()
            }
            tktArr.push(obj);
        });
        return tktArr;
    }


    function Ticket(obj) {
        var tkt = this;
        if (typeof obj === 'number') {
            tkt.type = ko.observable(obj);
            tkt.name = ko.observable('');
            tkt.quantity = ko.observable('');
            tkt.price = ko.observable('');
            tkt.eventTicketID = ko.observable(0);
            
        }
        else {
            tkt.type = ko.observable(obj.Type);
            tkt.name = ko.observable(obj.Name);
            tkt.quantity = ko.observable(obj.Quantity);
            tkt.price = ko.observable(obj.Price);
            tkt.eventTicketID = ko.observable(obj.EventTicketID);
        }
        tkt.deletetkt = function () {
            var r = confirm("Do you want to delete this !");
            if (r == true) {
                vm.ticketList.remove(tkt);
            }
        }

    }

    //location fucntions
    vm.resetLocation = function() {
        showLocationPicker();
    }

    //create Event fucntions
    vm.createEvent = function() {
        EventObj = {
            EventID: vm.evetnID(),
            Title: vm.title(),
            VenueName:vm.venueName(),
            Address:vm.address(),
            Address1:vm.address1(),
            CountryCode:vm.countryCode(),
            Postcode:vm.postcode(),
            City:vm.city(),
            Country: vm.country(),
            EventStart: $('#startDate').val() + ' ' + $('#startTime').val(),
            EventEnd: $('#endDate').val() + ' ' + $('#endTime').val(),
            EventDescription: tinyMCE.activeEditor.getContent(),
            EventTicketList: vm.getTicketData(),
        }
        $.ajax({
            url: 'http://localhost/App.UI/api/Event/CreateEvent/',
            type: 'POST',
            data: EventObj,
            dataType: "json",
            async: true,
            success: function (data) {
                alert("saved successfully");
                
            }
        });
    }

    vm.loadEvent = function () {

        EventObj = {
            evenID: vm.evetnID()
        }
        $.ajax({
            url: 'http://localhost/App.UI/api/Event/GetEvetByID/',
            type: 'GET',
            data: EventObj,
            dataType: "json",
            async: true,
            success: function (data) {

                if (data) {
                    if (data.ResultStatus.IsSuccess) {
                        var rtn = data.Result;
                        vm.title(rtn.Title);
                        vm.venueName(rtn.VenueName);
                        vm.address(rtn.Address);
                        vm.address1(rtn.Address1);
                        vm.city(rtn.City);
                        vm.countryCode(rtn.CountryCode);
                        vm.postcode(rtn.Postcode);
                        vm.country(rtn.Country);
                        $('textarea').html(rtn.EventDescription);
                        showLocationDetails();
                        vm.ticketList.removeAll();
                        ko.utils.arrayForEach(rtn.EventTicketList, function (current) {
                            vm.ticketList.push(new
                                Ticket(current));
                        });
                        $('#startDate').val(getFormatDate(new Date(rtn.EventStart)));
                        $('#startTime').val(getFormatTime(new Date(rtn.EventStart)));
                        $('#endDate').val(getFormatDate(new Date(rtn.EventEnd)));
                        $('#endTime').val(getFormatTime(new Date(rtn.EventEnd)));

                    }

                }
                console.log(data);
            }
        });
    }

}