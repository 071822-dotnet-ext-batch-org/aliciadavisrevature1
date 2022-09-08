"use strict;"

const xhr = new XMLHttpRequest();
console.log(`The readystate is ${xhr.readystate}`);


xhr.onreadystatechange = () => {
  console.log(`The readystate is ${xhr.readyState} - \nThe status code is ${xhr.status}`)
  if (xhr.readyState == 4 && xhr.status == 200) {
    console.log(`The responsetype is ${xhr.responseType.valueOf}.`);
    console.log(`The responsetext is ${xhr.responseText}`);
    displyResponseTextInBrowser();
  }
  else {
    console.log(`Jokes are not ready yet!`);
  }
};

xhr.open('GET', 'http://api.icndb.com/jokes/random', true);
xhr.send();

// I want a div that I can put p elements 
// into to display the joke text
function displyResponseTextInBrowser() {
  //get the body object
  let bodie = document.body;
  //create the div
  let myDiv = document.createElement('div');
  //create the p element
  let myP = document.createElement('p');
  //add the div and p to the html
  myDiv.appendChild(myP);
  bodie.appendChild(myDiv)
  //convert the JSON string into a JS object
  let resText = JSON.parse(xhr.responseText);
  console.log(resText)
  //add the text to the p element
  myP.textContent = resText.value.joke;

}

// now get 5 Jokes
const xhr2 = new XMLHttpRequest();
console.log(`The readystate is ${xhr2.readystate} - \nThe status code is ${xhr2.status}`);

xhr2.onreadystatechange = () => {
  if (xhr2.readyState == 4 && xhr2.status == 200) {
    console.log(`The responsetype is ${xhr2.responseType.valueOf}.`);
    console.log(`The responsetext is ${xhr2.responseText}`);
    displyJokesInBrowser();
  }
  else {
    console.log(`Jokes are not ready yet!`);
  }
};

let five = 5;
xhr2.open('GET', `http://api.icndb.com/jokes/random/${five}`, true);
xhr2.send();

function displyJokesInBrowser() {

  console.log(xhr2.responseText);
  //get the new div element
    let paras = document.getElementsByTagName('li');
    let MyArray = [];
    for (let i = 0; i < paras.length; i++) {
        MyArray.push(paras[i]);
    }
    let myDiv2 = document.querySelector('div');
    //let myP2 = document.querySelectorAll('p');
    let myLi = document.createElement('li')
    let counter = 1;
    let MyElem = 'li'
    for (let l1 of MyArray){
        counter++;
        myDiv2.innerHTML = `<${MyElem}>${counter} ${l1.textContent}</${MyElem}}>`;
    }
  //convert the JSON string into a JS object
    myDiv2.appendChild(myLi);
    //myP2.appendChild(myLi)
    let resText2 = JSON.parse(xhr2.responseText);
    console.log(resText2)
    myLi.textContent = resText2.value;

}

