require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';
import CarsComponent from './CarsComponent';
import ClientsComponent from './ClientsComponent';
import AppComponent from './Main';

require('styles//Navbar.css');

class NavbarComponent extends React.Component {
	
	constructor(){
		super();
		this.state = {
			isAuth: 'false'
		};
	}
	
	log(){
		var login = document.getElementById('login').value;
		var pass = document.getElementById('pass').value;
		
		var params = {
			username: 'Jazinho',
			password: 'SuperPass',
			grant_type: 'password'
		};

		var formBody = [];
		for (var property in params) {
			var encodedKey = encodeURIComponent(property);
			var encodedValue = encodeURIComponent(params[property]);
			formBody.push(encodedKey + "=" + encodedValue);
		}
		formBody = formBody.join("&");

		fetch('http://localhost:49791/token', {
		  method: 'POST',
		  headers: {
			'Accept': 'application/json',
			'Content-Type': 'x-www-form-urlencoded'
		  },
		  body: formBody
		})
		.then(response => response.json())
		.then(json => {
			if(json.hasOwnProperty('access_token')){
				this.setState({isAuth: 'true'});
			}
		});
	}
  
	register(){
		
	}
	
  render() {
    return (
		this.state.isAuth == 'false' ?
			<div className="logform-component">
				<div>
					<label><b>Login</b></label><br/>
					<input type="text" id="login" /><br/><br/>
					
					<label><b>Password</b></label><br/>
					<input type="password" id="pass" /><br/><br/>
					
					<div className="buttons"> 
						<button onClick={this.log.bind(this)}> Login </button>
						<button onClick={this.register.bind(this)}> Register </button>
					</div>
				</div>
			</div> :		
			<Router>
				<div className="navbar">
				  <ul>
					<li>
					  <Link to="/"> Home </Link>
					</li>
					<li>
					  <Link to="/cars"> Cars </Link>
					</li>
					<li>
					  <Link to="/clients"> Clients </Link>
					</li>
				  </ul>
				  <Route exact path="/" component={AppComponent} />
				  <Route path="/cars" component={() => (<CarsComponent isAuth={this.state.isAuth} />)}/>
				  <Route path="/clients" component={() => (<ClientsComponent isAuth={this.state.isAuth} />)} />
				</div>
			</Router> 
	);
  }
}

NavbarComponent.displayName = 'NavbarComponent';

// Uncomment properties you need
// NavbarComponent.propTypes = {};
// NavbarComponent.defaultProps = {};

export default NavbarComponent;
