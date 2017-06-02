'use strict';

import React from 'react';

require('styles/Clients.css');

let loadingGif = require('../images/loading.gif');

class ClientsComponent extends React.Component {
	constructor() {
		super();
		this.state = {
		  clientsList: null
		};
	}
	
	componentWillMount(){
		fetch('http://localhost:49642/Clients', {
		  method: 'GET',
		  headers: {
			'Accept': 'application/json'
		  }
		})
		.then((response) => response.json())
		.then((responseJson) => responseJson.value)
		.then((list) => this.setState({clientsList: list}));
	}
	
    render() {
		return (
			this.props.isAuth == 'true' ?
				(this.state.clientsList == null) ? <img src={loadingGif} alt='Loading...' /> : 
					<div className="clients-component"><ul> 
						{this.state.clientsList.map(client => (
							<li key={client.Id}> 
								<p>{client.Name} {client.Surname} </p>
							</li>
						))}
					</ul></div> :
			 <div> PERMISSION DENIED </div>
		);
    }
}

ClientsComponent.displayName = 'ClientsComponent';

// Uncomment properties you need
// ClientsComponent.propTypes = {};
// ClientsComponent.defaultProps = {};

export default ClientsComponent;
