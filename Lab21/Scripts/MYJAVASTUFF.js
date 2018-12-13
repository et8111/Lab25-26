function validate() {
    var flag = true;
    //first name
    if (document.getElementById("FirstName").value == "") {
        document.getElementById("FirstName").focus();
        document.getElementById("FirstName").setAttribute("class", "form-control is-invalid");
        document.getElementById("firstNameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("firstNameValidate").innerHTML = "Sorry, that first name is terrible. Try another?";
        flag = false;
    }
    else {
        document.getElementById("FirstName").setAttribute("class", "form-control is-valid");
        document.getElementById("firstNameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("firstNameValidate").innerHTML = "Successful!";
    }
    //last name
    if (document.getElementById("LastName").value == "") {
        document.getElementById("LastName").focus();
        document.getElementById("LastName").setAttribute("class", "form-control is-invalid");
        document.getElementById("lastNameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("lastNameValidate").innerHTML = "Sorry, ive never heard of 'blank'. Try a little harder?";
        flag = false;
    }
    else {
        document.getElementById("LastName").setAttribute("class", "form-control is-valid");
        document.getElementById("lastNameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("lastNameValidate").innerHTML = "Successful!";
    }
    //email
    if (document.getElementById("Email").value == "") {
        document.getElementById("Email").focus();
        document.getElementById("Email").setAttribute("class", "form-control is-invalid");
        document.getElementById("emailNameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("emailNameValidate").innerHTML = "Do i even have to say why...?";
        flag = false;
    } else {
        document.getElementById("Email").setAttribute("class", "form-control is-valid");
        document.getElementById("emailNameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("emailNameValidate").innerHTML = "Successful!";
    }
    //phone number
    if (document.getElementById("Phone").value.length != 10)
    {
        document.getElementById("Phone").focus();
        document.getElementById("Phone").setAttribute("class", "form-control is-invalid");
        document.getElementById("phoneNameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("phoneNameValidate").innerHTML = "I t S  j U s T  1 0  D i G i T s";
        flag = false;
    } else {
        document.getElementById("Phone").setAttribute("class", "form-control is-valid");
        document.getElementById("phoneNameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("phoneNameValidate").innerHTML = "Successful!";
    }
    //password 1
    if (document.getElementById("Password").value == "") {
        document.getElementById("Password").focus();
        document.getElementById("Password").setAttribute("class", "form-control is-invalid");
        document.getElementById("passNameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("passNameValidate").innerHTML = "Hey everyone there password is !";
        flag = false;
    } else {
        document.getElementById("Password").setAttribute("class", "form-control is-valid");
        document.getElementById("passNameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("passNameValidate").innerHTML = "Look at you go!";
    }
    //password 2
    if (document.getElementById("pass2").value != document.getElementById("Password").value || document.getElementById("pass2").value == "") {
        document.getElementById("pass2").focus();
        document.getElementById("pass2").setAttribute("class", "form-control is-invalid");
        document.getElementById("pass2NameValidate").setAttribute("class", "invalid-feedback");
        document.getElementById("pass2NameValidate").innerHTML = "holding your hand at this point";
        flag = false;
    } else {
        document.getElementById("pass2").setAttribute("class", "form-control is-valid");
        document.getElementById("pass2NameValidate").setAttribute("class", "valid-feedback");
        document.getElementById("pass2NameValidate").innerHTML = "Miracles DO happen!";
    }
        return (flag);
}
$(document).ready(function () {
    $("#pop1Background").slideDown(2000);
});

function HOVERSTUFF(e) {
    if (e.id == "listitem1")
        document.getElementById("itemDesc").innerHTML = "Its a Postcard.";
    if (e.id == "listitem2")
        document.getElementById("itemDesc").innerHTML = "Its a flyer.";
    if (e.id == "listitem3")
        document.getElementById("itemDesc").innerHTML = "Its a Mail Postcard, what there different.";
    if (e.id == "listitem4")
        document.getElementById("itemDesc").innerHTML = "Its a Certificate.";
    if (e.id == "listitem5")
        document.getElementById("itemDesc").innerHTML = "Its a Brochure.";
}

function HG() {
    var image = document.getElementById("img1").setAttribute("src", "https://upload.wikimedia.org/wikipedia/en/d/df/Marshall_Applewhite.jpg")
    setTimeout(function () {
        document.getElementById("img1").setAttribute("src", "http://comedycentral.mtvnimages.com/images/shows/chappelle/videos/season1/101_popcopy_v6.jpg");
    }, 50);
    
}