const apiUrl = 'https://localhost:5001';

// Predefined Data (as in your model)
const predefinedData = {
    peopleCategories: ["Employee", "Visitor", "Contractor", "Administrator", "Security"],
    areaCategories: ["Restricted Area", "Meeting Room", "Parking Lot", "Recreation Area", "Data Center"],
    services: ["Security Service", "Maintenance Service", "Cleaning Service", "IT Support", "Reception Service"]
};

async function populateDropdowns() {
    const peopleCategorySelect = document.getElementById("peopleCategory");
    const areaCategorySelect = document.getElementById("areaCategory");
    const serviceSelect = document.getElementById("serviceName");

    // Populate People Category dropdown
    predefinedData.peopleCategories.forEach(category => {
        const option = document.createElement('option');
        option.value = category;
        option.textContent = category;
        peopleCategorySelect.appendChild(option);
    });

    // Populate Area Category dropdown
    predefinedData.areaCategories.forEach(area => {
        const option = document.createElement('option');
        option.value = area;
        option.textContent = area;
        areaCategorySelect.appendChild(option);
    });

    // Populate Services dropdown
    predefinedData.services.forEach(service => {
        const option = document.createElement('option');
        option.value = service;
        option.textContent = service;
        serviceSelect.appendChild(option);
    });
}

async function addRestriction() {
    const categoryS = document.getElementById("peopleCategory").value;
    const categoryP = document.getElementById("areaCategory").value;

    const response = await fetch(`${apiUrl}/restrictions`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ categoryS, categoryP })
    });

    if (response.ok) {
        alert('Restriction added successfully!');
        loadRestrictions();
    } else {
        alert('Failed to add restriction.');
    }
}

async function loadRestrictions() {
    const response = await fetch(`${apiUrl}/restrictions`);
    const restrictions = await response.json();
    const list = document.getElementById('restrictionList');
    list.innerHTML = '';

    restrictions.forEach(restriction => {
        const item = document.createElement('li');
        item.textContent = `ID: ${restriction.id}, People Category (S): ${restriction.categoryS}, Area Category (P): ${restriction.categoryP}`;
        list.appendChild(item);
    });
}

async function editRestriction() {
    const id = document.getElementById("editRestrictionId").value;
    const categoryS = document.getElementById("editCategoryS").value;
    const categoryP = document.getElementById("editCategoryP").value;

    const response = await fetch(`${apiUrl}/restrictions/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ categoryS, categoryP })
    });

    if (response.ok) {
        alert('Restriction updated successfully!');
        loadRestrictions();
    } else {
        alert('Failed to update restriction.');
    }
}

async function deleteRestriction() {
    const id = document.getElementById("editRestrictionId").value;

    const response = await fetch(`${apiUrl}/restrictions/${id}`, {
        method: 'DELETE',
    });

    if (response.ok) {
        alert('Restriction deleted successfully!');
        loadRestrictions();
    } else {
        alert('Failed to delete restriction.');
    }
}

async function addService() {
    const serviceName = document.getElementById("serviceName").value;

    const response = await fetch(`${apiUrl}/services`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name: serviceName })
    });

    if (response.ok) {
        alert('Service added successfully!');
        loadServices();
    } else {
        alert('Failed to add service.');
    }
}

async function loadServices() {
    const response = await fetch(`${apiUrl}/services`);
    const services = await response.json();
    const list = document.getElementById('serviceList');
    list.innerHTML = '';

    services.forEach(service => {
        const item = document.createElement('li');
        item.textContent = `ID: ${service.id}, Service Name: ${service.name}`;
        list.appendChild(item);
    });
}

async function editService() {
    const id = document.getElementById("editServiceId").value;
    const name = document.getElementById("editServiceName").value;

    const response = await fetch(`${apiUrl}/services/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name })
    });

    if (response.ok) {
        alert('Service updated successfully!');
        loadServices();
    } else {
        alert('Failed to update service.');
    }
}

async function deleteService() {
    const id = document.getElementById("editServiceId").value;

    const response = await fetch(`${apiUrl}/services/${id}`, {
        method: 'DELETE',
    });

    if (response.ok) {
        alert('Service deleted successfully!');
        loadServices();
    } else {
        alert('Failed to delete service.');
    }
}

// Load predefined data and lists on window load
window.onload = async function() {
    await populateDropdowns();
    loadRestrictions();
    loadServices();
}
