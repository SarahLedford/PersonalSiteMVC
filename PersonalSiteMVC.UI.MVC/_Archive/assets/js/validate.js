function validateForm(event) {

    let controls = document.getElementsByClassName('form-control');
    console.log(controls);

    let validationMessages = document.getElementsByClassName('invalid');


    let rxpEmail = new RegExp(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/);

    if (controls['name'].value.length === 0 || controls['email'].value.length === 0 || controls['subject'].value.length === 0 || controls['message'].value.length === 0 || !rxpEmail.test(controls['email'].value)) {
        //Stop form from submitting:
        event.preventDefault();

        //Check individual controls and display error messages as needed:
        //----------------Name-----------
        if (controls['name'].value.length === 0) {
            validationMessages['errorName'].textContent = "*Name is requried";
        }
        else {
            validationMessages['errorName'].textContent = "";
        }

        //Email
        if (controls['email'].value.length === 0) {
            validationMessages['errorEmail'].textContent = "*Email is requried";
        }
        else {
            validationMessages['errorEmail'].textContent = "";
        }
        if (!rxpEmail.test(controls['email'].value) && controls['email'].value.length > 0) {
            validationMessages['errorEmail'].textContent = '*Please enter a valid email address';
        }
        if (rxpEmail.test(controls['email'].value) && controls['email'].value.length > 0) {
            validationMessages['errorEmail'].textContent = '';
        }

        //subject
        if (controls['subject'].value.length === 0) {
            validationMessages['errorSubject'].textContent = "*Subject is requried";
        }
        else {
            validationMessages['errorSubject'].textContent = "";
        }

        //message
        if (controls['message'].value.length === 0) {
            validationMessages['errorMessage'].textContent = "*Message is requried";
        }
        else {
            validationMessages['errorMessage'].textContent = "";
        }
    }
}