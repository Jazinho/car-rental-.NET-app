'use strict';

import React from 'react';

require('styles/Cars.css');

let loadingGif = require('../images/loading.gif');

class CarsComponent extends React.Component {
	
	constructor() {
		super();
		this.state = {
		  carsList: null
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
		.then((list) => this.setState({carsList: list}));
	}
	
	render() {
		return (
			this.props.isAuth == 'true' ? 
				this.state.carsList == null ? <img src={loadingGif} alt='Loading...' /> : 
					<div className="cars-component"><ul> 
						{this.state.carsList.map(car => (
							<li key={car.Id}> 
								<p>{car.Brand} {car.Model} </p>
								<table>			
									<tbody>
									<tr> 
										<td>Type:</td><td>{car.Type}</td>
									</tr>
									<tr> 
										<td>Passed Kms:</td><td>{car.PassedKms}</td>
									</tr>
									<tr> 								
										<td>Production Year:</td><td>{car.ProductionYear}</td>
									</tr>
									<tr> 
										<td>Price:</td><td>{car.Price}</td>
									</tr>
									</tbody>
								</table>
							</li>
						))}
			</ul></div> :
			 <div> PERMISSION DENIED </div>
		);
    }
}

CarsComponent.displayName = 'CarsComponent';

// Uncomment properties you need
// CarsComponent.propTypes = {};
CarsComponent.defaultProps = {};

export default CarsComponent;
