'use strict';

import React from 'react';

require('styles/Cars.css');

let loadingGif = require('../images/loading.gif');

class CarsComponent extends React.Component {
	
	constructor() {
		super();
		this.state = {
		  carsList: []
		};
	}
	
	componentWillMount(){
		
		fetch('http://localhost:49635/Cars', {
		  method: 'GET',
		  headers: {
			'Accept': 'application/json'
		  }
		})
		.then((response) => response.json())
		.then((responseJson) => responseJson.value)
		.then((list) => this.setState({list}));
		
		console.log(this.state.carsList);
	}
	
	render() {
		return (
			!this.state.carsList ? <img src={loadingGif} alt='Loading...' /> : 
				<div className="cars-component"><ul> 
					{this.state.carsList.map(car => (
						<li key={car.Id}> {car.Brand} {car.Model} <br/> Type: {car.Type} <br/> Passed Kms: {car.PassedKms} <br/> Production Year: {car.ProductionYear} <br/> <br/> Price: <b>{car.Price}</b></li>
					))}
				</ul></div>
		);
    }
}

CarsComponent.displayName = 'CarsComponent';

// Uncomment properties you need
// CarsComponent.propTypes = {};
// CarsComponent.defaultProps = {};

export default CarsComponent;
