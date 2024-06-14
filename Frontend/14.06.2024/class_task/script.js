(function() {
    'use strict';

    var predefinedProfessions = ["Engineer", "Doctor", "Teacher"];
    var professionInput = document.getElementById('profession');
    var professionDatalist = document.getElementById('professions');

    function populateProfessions() {
        predefinedProfessions.forEach(function(profession) {
            var option = document.createElement('option');
            option.value = profession;
            
            professionDatalist.appendChild(option);
        });
    }

    function calculateAge(dob) {
        var birthDate = new Date(dob);
        var today = new Date();
        var age = today.getFullYear() - birthDate.getFullYear();
        var monthDiff = today.getMonth() - birthDate.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        return age;
    }

    window.addEventListener('load', function() {
        populateProfessions();

        var form = document.getElementById('registrationForm');
        var dobInput = document.getElementById('dob');
        var ageInput = document.getElementById('age');

        dobInput.addEventListener('change', function() {
            var age = calculateAge(dobInput.value);
            ageInput.value = age;
        });

        professionInput.addEventListener('input', function() {
            var value = professionInput.value;
            if (value && !predefinedProfessions.includes(value)) {
                predefinedProfessions.push(value);
                var option = document.createElement('option');
                option.value = value;
                professionDatalist.appendChild(option);
            }
        });

        form.addEventListener('submit', function(event) {
            event.preventDefault();
            event.stopPropagation();

            var isFormValid = true;

            // Check validity for each input field
            if (!form.checkValidity()) {
                isFormValid = false;
                markInvalidFields();
            }

            // Check for checkbox validation
            var checkboxes = form.querySelectorAll('input[name="qualification"]');
            var isChecked = Array.prototype.slice.call(checkboxes).some(x => x.checked);
            if (!isChecked) {
                document.getElementById('qualification-feedback').style.display = 'block';
                isFormValid = false;
            } else {
                document.getElementById('qualification-feedback').style.display = 'none';
            }

            // Check for gender radio button validation
            var genderRadios = form.querySelectorAll('input[name="gender"]');
            var isGenderSelected = Array.prototype.slice.call(genderRadios).some(x => x.checked);
            if (!isGenderSelected) {
                document.getElementById('gender-feedback').style.display = 'block';
                isFormValid = false;
            } else {
                document.getElementById('gender-feedback').style.display = 'none';
            }

            // Check for profession input validation
            if (!professionInput.value) {
                document.getElementById('profession-feedback').style.display = 'block';
                isFormValid = false;
            } else {
                document.getElementById('profession-feedback').style.display = 'none';
            }

            if (!isFormValid) {
                form.classList.add('was-validated');
                return;
            }

            form.classList.remove('was-validated');
            // Proceed with form submission or further processing
            alert('Form submitted successfully!');
        }, false);

        // Function to mark invalid fields on form submit
        function markInvalidFields() {
            var inputs = form.querySelectorAll('.form-control');
            inputs.forEach(function(input) {
                if (!input.checkValidity()) {
                    input.classList.add('is-invalid');
                    input.classList.remove('is-valid');
                } else {
                    input.classList.remove('is-invalid');
                    input.classList.add('is-valid');
                }
            });

            // Checkbox validation
            var checkboxes = form.querySelectorAll('input[name="qualification"]');
            var isChecked = Array.prototype.slice.call(checkboxes).some(x => x.checked);
            if (!isChecked) {
                document.getElementById('qualification-feedback').style.display = 'block';
            } else {
                document.getElementById('qualification-feedback').style.display = 'none';
            }

            // Radio button validation
            var genderRadios = form.querySelectorAll('input[name="gender"]');
            var isGenderSelected = Array.prototype.slice.call(genderRadios).some(x => x.checked);
            if (!isGenderSelected) {
                document.getElementById('gender-feedback').style.display = 'block';
            } else {
                document.getElementById('gender-feedback').style.display = 'none';
            }

            // Display specific error messages on invalid input
            document.getElementById('name-feedback').style.display = document.getElementById('name').validity.valueMissing ? 'block' : 'none';
            document.getElementById('phone-feedback').style.display = document.getElementById('phone').validity.patternMismatch ? 'block' : 'none';
            document.getElementById('dob-feedback').style.display = document.getElementById('dob').validity.valueMissing ? 'block' : 'none';
            document.getElementById('email-feedback').style.display = document.getElementById('email').validity.typeMismatch ? 'block' : 'none';
            document.getElementById('profession-feedback').style.display = !professionInput.value ? 'block' : 'none';
        }

        // Event listener for input fields to toggle validity classes
        form.addEventListener('input', function(event) {
            var field = event.target;
            if (field.checkValidity()) {
                field.classList.remove('is-invalid');
                field.classList.add('is-valid');

                // Hide specific error messages on valid input
                if (field.id === 'name') {
                    document.getElementById('name-feedback').style.display = 'none';
                } else if (field.id === 'phone') {
                    document.getElementById('phone-feedback').style.display = 'none';
                } else if (field.id === 'dob') {
                    document.getElementById('dob-feedback').style.display = 'none';
                } else if (field.id === 'email') {
                    document.getElementById('email-feedback').style.display = 'none';
                } else if (field.id === 'profession') {
                    document.getElementById('profession-feedback').style.display = 'none';
                }
            } else {
                field.classList.remove('is-valid');
                field.classList.add('is-invalid');
            }
        });

        // Event listener for checkbox and radio button validation on change
        var checkboxes = form.querySelectorAll('input[type="checkbox"]');
        checkboxes.forEach(function(checkbox) {
            checkbox.addEventListener('change', function() {
                var isChecked = Array.prototype.slice.call(checkboxes).some(x => x.checked);
                if (isChecked) {
                    document.getElementById('qualification-feedback').style.display = 'none';
                }
            });
        });

        var genderRadios = form.querySelectorAll('input[name="gender"]');
        genderRadios.forEach(function(radio) {
            radio.addEventListener('change', function() {
                var isGenderSelected = Array.prototype.slice.call(genderRadios).some(x => x.checked);
                if (isGenderSelected) {
                    document.getElementById('gender-feedback').style.display = 'none';
                }
            });
        });

    }, false);
})();
 