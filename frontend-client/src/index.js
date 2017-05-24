
import React from 'react';
import ReactDOM from 'react-dom';
import AppComponent from './components/Main';

// Render the main component into the dom
ReactDOM.render(<AppComponent/>, document.getElementById('app'));

function clear(){
  ReactDOM.render(<AppComponent/>, document.getElementById('app'));
}
