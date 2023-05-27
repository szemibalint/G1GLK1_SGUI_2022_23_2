let consumers = [];
let consumerIdToUpdate = -1;
let orders = [];
let orderIdToUpdate = -1;
let restaurants = [];
let restaurantIdToUpdate = -1;
let mostOftenOrderedfood = "";

getDataConsumer();
getDataOrder();
getDataRestaurant();



async function getDataConsumer() {
    await fetch('http://localhost:5184/consumer')
        .then(x => x.json())
        .then(y => {
            consumers = y;
            console.log(consumers);
            displayConsumer();
        });
}

async function getDataOrder() {
    await fetch('http://localhost:5184/order')
        .then(x => x.json())
        .then(y => {
            orders = y;
            console.log(orders);
            displayOrder();
        });
}
async function getDataRestaurant() {
    await fetch('http://localhost:5184/restaurant')
        .then(x => x.json())
        .then(y => {
            restaurants = y;
            console.log(restaurants);
            displayRestaurant();
        });
}



function removeConsumer(id) {
    fetch('http://localhost:5184/consumer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataConsumer();
        })
        .catch((error) => { console.error('Error:', error); })
}

function removeOrder(id) {
    fetch('http://localhost:5184/order/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataOrder();
        })
        .catch((error) => { console.error('Error:', error); })
}

function removeRestaurant(id) {
    fetch('http://localhost:5184/restaurant/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataRestaurant();
        })
        .catch((error) => { console.error('Error:', error); })
}



function displayConsumer() {
    document.getElementById('resultareaconsumer').innerHTML = "";
    consumers.forEach(t => {
        document.getElementById('resultareaconsumer').innerHTML +=
            "<tr><td>" + t.consumerId + "</td><td>" + t.name + "/ " + t.address + "</td><td>" + `<button type="button" onclick="removeConsumer(${t.consumerId})">Delete</button>` +
        `<button type="button" onclick="showupdateconsumer(${t.consumerId})">Update</button>`
            + "</td></tr>";
    });
}

function displayOrder() {
    document.getElementById('resultareaorder').innerHTML = "";
    orders.forEach(t => {
        document.getElementById('resultareaorder').innerHTML +=
            "<tr><td>" + t.orderId + "</td><td>" + t.food + ": " +  t.price + "</td><td>" +`<button type="button" onclick="removeOrder(${t.orderId})">Delete</button>` +
        `<button type="button" onclick="showupdateorder(${t.orderId})">Update</button>`
            + "</td></tr>";
    });
}

function displayRestaurant() {
    document.getElementById('resultarearestaurant').innerHTML = "";
    restaurants.forEach(t => {
        document.getElementById('resultarearestaurant').innerHTML +=
            "<tr><td>" + t.restaurantId + "</td><td>" + t.name + "/ " + t.location + "/ " + t.cuisine + "</td><td>" + `<button type="button" onclick="removeRestaurant(${t.restaurantId})">Delete</button>` +
        `<button type="button" onclick="showupdaterestaurant(${t.restaurantId})">Update</button>`
            + "</td></tr>";
    });
}

function showupdateconsumer(id) {
    document.getElementById('consumernametoupdate').value = consumers.find(t => t['consumerId'] == id)['name'];
    document.getElementById('consumeraddresstoupdate').value = consumers.find(t => t['consumerId'] == id)['address'];
    document.getElementById('updateformdivconsumer').style.display = 'unset';
    consumerIdToUpdate = id;
}

function showupdateorder(id) {
    document.getElementById('ordernametoupdate').value = orders.find(t => t['orderId'] == id)['food'];
    document.getElementById('orderpricetoupdate').value = orders.find(t => t['orderId'] == id)['price'];
    document.getElementById('updateformdivorder').style.display = 'unset';
    orderIdToUpdate = id;
}

function showupdaterestaurant(id) {
    document.getElementById('restaurantnametoupdate').value = restaurants.find(t => t['restaurantId'] == id)['name'];
    document.getElementById('restaurantlocationtoupdate').value = restaurants.find(t => t['restaurantId'] == id)['location'];
    document.getElementById('restaurantcuisinetoupdate').value = restaurants.find(t => t['restaurantId'] == id)['cuisine'];
    document.getElementById('updateformdivrestaurant').style.display = 'unset';
    restaurantIdToUpdate = id;
}

function getMostOftenOrderedFood() {
    let consumerId = document.getElementById('consumerId').value;
    const request = new XMLHttpRequest();
    request.open("GET", `http://localhost:5184/consumer/${consumerId}/food`);
    request.send();
    request.onload = () => {
        if (request.status === 200) {
            console.log(request.response);
            document.getElementById('mostoftenorderedfood').innerHTML = request.response;
        }
        else {
            console.log(`error ${request.status}`);
        }
    }
}

function getMostOrdersFromRestaurant() {
    let consumerId = document.getElementById('consumerId').value;
    const request = new XMLHttpRequest();
    request.open("GET", `http://localhost:5184/consumer/${consumerId}/restaurant`);
    request.send();
    request.onload = () => {
        if (request.status === 200) {
            console.log(request.response);
            document.getElementById('mostordersfromrestaurant').innerHTML = request.response;
        }
        else {
            console.log(`error ${request.status}`);
        }
    }
}

function getConsumerNameFromOrder() {
    let orderId = document.getElementById('orderId').value;
    const request = new XMLHttpRequest();
    request.open("GET", `http://localhost:5184/order/${orderId}/name`);
    request.send();
    request.onload = () => {
        if (request.status === 200) {
            console.log(request.response);
            document.getElementById('consumernamefromorder').innerHTML = request.response;
        }
        else {
            console.log(`error ${request.status}`);
        }
    }
}

function getConsumerAddressFromOrder() {
    let orderId = document.getElementById('orderId').value;
    const request = new XMLHttpRequest();
    request.open("GET", `http://localhost:5184/order/${orderId}/address`);
    request.send();
    request.onload = () => {
        if (request.status === 200) {
            console.log(request.response);
            document.getElementById('consumeraddressfromorder').innerHTML = request.response;
        }
        else {
            console.log(`error ${request.status}`);
        }
    }
}

function getConsumerWithMostOrders() {
    const request = new XMLHttpRequest();
    request.open("GET", `http://localhost:5184/restaurant/orders`);
    request.send();
    request.onload = () => {
        if (request.status === 200) {
            console.log(request.response);
            document.getElementById('consumerwithmostorders').innerHTML = request.response;
        }
        else {
            console.log(`error ${request.status}`);
        }
    }
}

function createConsumer() {
    let name = document.getElementById('consumerName').value;
    let address = document.getElementById('consumerAddress').value;
    fetch('http://localhost:5184/consumer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, locationid: 1, address: address, locationid: 1 }),
            
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataConsumer();
        })
        .catch((error) => { console.error('Error:', error); });

}



function createOrder() {
    let food = document.getElementById('orderName').value;
    let price = document.getElementById('orderPrice').value;
    fetch('http://localhost:5184/order', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { food: food, locationid: 1, price: price, locationid: 1 }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataOrder();
        })
        .catch((error) => { console.error('Error:', error); });

}


function createRestaurant() {
    let name = document.getElementById('restaurantName').value;
    let cuisine = document.getElementById('restaurantCuisine').value;
    let location = document.getElementById('restaurantLocation').value;
    fetch('http://localhost:5184/restaurant', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, locationid: 1, cuisine: cuisine, locaitonid: 1, location: location, locationid: 1 }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataRestaurant();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateConsumer() {
    document.getElementById('updateformdivconsumer').style.display = 'none';
    let name = document.getElementById('consumernametoupdate').value;
    fetch('http://localhost:5184/consumer/name', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, locationid: 1, ConsumerID: consumerIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataConsumer();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateConsumerAddress() {
    document.getElementById('updateformdivconsumer').style.display = 'none';
    let address = document.getElementById('consumeraddresstoupdate').value;
    fetch('http://localhost:5184/consumer/address', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { address: address, locationid: 1, ConsumerID: consumerIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataConsumer();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateOrder() {
    document.getElementById('updateformdivorder').style.display = 'none';
    let food = document.getElementById('ordernametoupdate').value;
    let price = document.getElementById('orderpricetoupdate').value;
    fetch('http://localhost:5184/order', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { food: food, locationid: 1, OrderID: orderIdToUpdate, price: price, locationid: 1, OrderID: orderIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataOrder();
        })
        .catch((error) => { console.error('Error:', error); });

}



function updateRestaurant() {
    document.getElementById('updateformdivrestaurant').style.display = 'none';
    let name = document.getElementById('restaurantnametoupdate').value;
    fetch('http://localhost:5184/restaurant/name', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, RestaurantID: restaurantIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataRestaurant();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateRestaurantLocation() {
    document.getElementById('updateformdivrestaurant').style.display = 'none';
    let location = document.getElementById('restaurantlocationtoupdate').value;
    fetch('http://localhost:5184/restaurant/location', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { location: location, RestaurantID: restaurantIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataRestaurant();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateRestaurantCuisine() {
    document.getElementById('updateformdivrestaurant').style.display = 'none';
    let cuisine = document.getElementById('restaurantcuisinetoupdate').value;
    fetch('http://localhost:5184/restaurant/cuisine', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { cuisine: cuisine, RestaurantID: restaurantIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDataRestaurant();
        })
        .catch((error) => { console.error('Error:', error); });

}