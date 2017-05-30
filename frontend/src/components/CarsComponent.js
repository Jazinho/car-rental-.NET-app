'use strict';

import React from 'react';

require('styles//Cars.css');

class CarsComponent extends React.Component {
	
	
  render() {
	  /*
	  var myHeaders = new Headers();
	  myHeaders.append('Access-Control-Allow-Origin', '*');
	  myHeaders.append('Accept', 'application/json');
	  
	var myInit = { method: 'GET',
               headers: myHeaders,
               mode: 'cors',
               cache: 'default'};

	console.log('autka');
	var cars = fetch('http://localhost:49635/Cars', myInit).then(function(response) {
	  console.log(response.json());
	  return response.json();
	});
	*/
	var cars;
	fetch('http://localhost:49635/Cars', {
	  method: 'GET',
	  headers: {
		'Accept': 'application/json'/*,
		'Access-Control-Allow-Origin': '*',
		'mode': 'no-cors'*/
	  }
	})
	.then((response) => response.json())
	.then((responseJson) => { cars = responseJson.value; console.log(cars); })
	

    return (
      <div className="cars-component">
        <p>Cars Cars Cars</p>
      </div>
    );
  }
}

CarsComponent.displayName = 'CarsComponent';

// Uncomment properties you need
// CarsComponent.propTypes = {};
// CarsComponent.defaultProps = {};

export default CarsComponent;
