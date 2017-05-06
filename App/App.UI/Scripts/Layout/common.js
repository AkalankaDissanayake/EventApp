function getFormatDate(d) {

    return d.getFullYear() + '/' + (parseInt(d.getMonth(),0)+1) + '/' + d.getDate();
}
function getFormatTime(d){
    var d = new Date();
    return d.getHours() + ':' + d.getMinutes();
}
function GetParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}