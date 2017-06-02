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
			userName: login,
			password: pass,
			grant_type: 'password'
		};
		
		var formData = new FormData();

		for (var k in params) {
			formData.append(k, params[k]);
		}

		fetch('http://localhost:49791/token', {
		  method: 'POST',
		  headers: {
			'Accept': 'application/json',
			'Content-Type': 'x-www-form-urlencoded'
		  },
		  body: formData
		})
		.then((response) => response.json().access_token)
		.then((token) => this.setState({isAuth: 'true'})); //
		
		//;
		
	}
  
	register(){
		
	}
	
	
  render() {
    return (
		this.state.isAuth == 'false' ?
			<div className="logform-component">
				<form>
					<label><b>Login</b></label><br/>
					<input type="text" name="login" /><br/><br/>
					
					<label><b>Password</b></label><br/>
					<input type="password" name="pass" /><br/><br/>
					
					<div class="buttons"> 
						<button onClick={this.log.bind(this)}> Login </button>
						<button onClick={this.register.bind(this)}> Register </button>
					</div>
				</form>
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
