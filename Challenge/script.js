//Getting the elements
const form = document.getElementById('form');
const state = document.getElementById('state');
const dateOfBirth = document.getElementById('dateOfBirth');
const age = document.getElementById('age');
const plan = document.getElementById('plan');
const stateId = document.getElementById('stateId');
const planId = document.getElementById('planId');
const showDiv = document.getElementById('showDiv');
const selectFreq = document.getElementById('selectFreq');
const tbody = document.getElementById("tbody");

var stateArray = [];
const planArray = ['A', 'B', 'C'];
var premiumArray = [];

//Set default Date for date of birth
var today = new Date();
dateOfBirth.valueAsDate = today;
dateOfBirth.max = today.toISOString().split("T")[0];
showDiv.style.display = 'none';

//GET States
fetch('https://localhost:44351/getStates').then(res => res.json()).then((out) => {
    stateArray = out;
    out.forEach(function (element) {
        var option = document.createElement('option');
        option.value = element;
        state.appendChild(option);
    });

}).catch(function (err) {
    alert('Something went wrong.', err);
});


//Date of birth event listener
dateOfBirth.addEventListener("input", function (e) {     
    age.value = getAge(e.srcElement.value);
});

//selectFreq event listener
selectFreq.addEventListener("input", function (e) {
    calculateFrequencies(premiumArray, e.srcElement.value );
});

//Set age for date of birth

function getAge(date) {
    var semiDate = new Date(date); 
    var dateString = new Date(semiDate.getTime() + Math.abs(semiDate.getTimezoneOffset() * 60000)); 
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}


//GET Premium
function getPremium(plan, state, dateOfBirth, age) {   
    let stateCode = state.split('-')[0];

    fetch('https://localhost:44351/getPremium?plan=' + plan + '&state= ' + stateCode+'&dateOfBirth='+ dateOfBirth+'&age='+age).then(res => res.json()).then((out) => {

        selectFreq.value = "";
        calculateFrequencies(out, 'n');

        if (out.length > 1) {
            showDiv.style.display = 'block';
        } else {
            showDiv.style.display = 'none';
        }

        
        premiumArray = out;
    }).catch(function (err) {
          alert( err);
    });
}



//Calculate Frequencies

function calculateFrequencies(data, type) {

    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.lastChild);
    }



    data.forEach(function (element) {
        var ann = 0;
        var mon = 0;
        switch (type) {
            case 'm':
                ann = element.premium * 12;
                mon = element.premium;
                break;
            case 'q':
                ann = element.premium * 4;
                mon = element.premium/ 3;
                break;
            case 'sa':
                ann = element.premium * 6;
                mon = element.premium / 6;
                break;
            case 'a':
                ann = element.premium;
                mon = element.premium / 12;
                break;
    }

        let table = document.getElementById("table").getElementsByTagName('tbody')[0]
        let row = table.insertRow(table.length);

        col2 = row.insertCell(0).innerHTML = element.carrier;
        col3 = row.insertCell(1).innerHTML = element.premium.toFixed(2);
        col4 = row.insertCell(2).innerHTML = ann.toFixed(2);
        col5 = row.insertCell(3).innerHTML = mon.toFixed(2)

    }); 

}


 


// Submit
form.addEventListener('submit', function (e) {
    e.preventDefault(); 
    isValid = false;
    var validForm = checkRequired([dateOfBirth, age]);
    var validPlan = checkInputArray(planArray, planId.value, planId);
    var validState = checkInputArray(stateArray, stateId.value, stateId );
    if (validForm || validPlan || validState) {
        return;
    }
    getPremium(planId.value, stateId.value, dateOfBirth.value, age.value);

});


// Show input error message
function showError(input, message) {
  const formControl = input.parentElement;
  formControl.className = 'form-control error';
  const small = formControl.querySelector('small');
  small.innerText = message;
}

// Show success outline
function showSuccess(input) {
  const formControl = input.parentElement;
  formControl.className = 'form-control success';
}

//Check if input is present in array

function checkInputArray(array, string, input) {

    if (string.length == 0) {
        showError(input, `${getFieldName(input)} is required`);
        return true;
    }

    let isInArray = array.includes(string);
    if (!isInArray) {
        showError(input, `${getFieldName(input)} is required`);
        return true;
    }
    showSuccess(input);
    return false;
}



// Check required fields
function checkRequired(inputArr) {
    let isRequired = false;
    inputArr.forEach(function (input) {
        if (input.value.trim() === '') {
      showError(input, `${getFieldName(input)} is required`);
      isRequired = true;
    } else {
      showSuccess(input);
    }
  });

  return isRequired;
}

 
// Get fieldname
function getFieldName(input) {
  return input.id.charAt(0).toUpperCase() + input.id.slice(1);
}



