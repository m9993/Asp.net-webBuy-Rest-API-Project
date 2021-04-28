function deleteAllCookies() {
    document.cookie.split(";").forEach(function(c) { document.cookie = c.replace(/^ +/, "").replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/"); });
}

function logout(){
    deleteAllCookies();
    $(location).attr('href',"/webBuy App/index.html");
}