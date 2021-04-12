function CreateProject(){
    const projectName = document.getElementById("projectName").value;
    const managerName = document.getElementById("managerName").value;
    const contactInfo = document.getElementById("contactInfo").value;
    var paymentInfo;

    var payment = document.getElementsByName('payment');

    for (var i = 0, length = payment.length; i < length; i++) {
        if (payment[i].checked) {
        
        paymentInfo = payment[i].value;

        // only one radio can be checked, don't check the rest
        break;
        }
    }


    console.log(projectName);
    console.log(managerName);
    console.log(contactInfo);
    console.log(paymentInfo);
}

function UpdatePost(){
    const id = document.getElementById("idUpdate").value;
    const update = document.getElementById("updateText").value;

    console.log(id);
    console.log(update);
}


function editStatus(){
    const idvalue = document.getElementById("idStatus").value;
    
    var statusInfo;

    var status = document.getElementsByName('status');

    for (var i = 0, length = status.length; i < length; i++) {
        if (status[i].checked) {
        
        statusInfo = status[i].value;

        // only one radio can be checked, don't check the rest
        break;
        }
    }

    console.log(idvalue);
    console.log(statusInfo);
}

function UpdatePost(){
    const id = document.getElementById("idUpdate").value;
    const update = document.getElementById("updateText").value;

    console.log(id);
    console.log(update);
}

function RemovePost(){
    const update = document.getElementById("idRemove").value;

    console.log(update);
}

function MarkComplete(){
    const update = document.getElementById("idComplete").value;

    console.log(update);
}