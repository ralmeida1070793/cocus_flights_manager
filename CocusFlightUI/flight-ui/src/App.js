import React from 'react';
import AddAeroplane from './Aeroplanes/AddAeroplane';
import AeroplanesList from './Aeroplanes/AeroplanesList';
import EditAeroplane from './Aeroplanes/EditAeroplane';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import './App.css';
function App() {
    return (
        <Router>
            <div className="container">
                <nav className="navbar navbar-expand-lg navheader">
                    <div className="collapse navbar-collapse" >
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item">
                                <Link to={'/AddAeroplane'} className="nav-link">Add Aeroplane</Link>
                            </li>
                            <li className="nav-item">
                                <Link to={'/AeroplanesList'} className="nav-link">Aeroplanes List</Link>
                            </li>
                        </ul>
                    </div>
                </nav> <br />
                <Switch>
                    <Route exact path='/AddAeroplane' component={AddAeroplane} />
                    <Route path='/edit/:id' component={EditAeroplane} />
                    <Route path='/AeroplanesList' component={AeroplanesList} />
                </Switch>
            </div>
        </Router>
    );
}

export default App;
