import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';

export default class AeroplaneList extends Component {

    constructor(props) {
        super(props);
        this.state = {business: []};
    }
    componentDidMount(){
        debugger;
        axios.get('https://localhost:44356/api/aeroplanes')
            .then(response => {
                this.setState({ business: response.data.entities });
                debugger;

            })
            .catch(function (error) {
                console.log(error);
            })
    }

    tabRow(){
        return this.state.business.map(function(object, i){
            return <Table obj={object} key={i} />;
        });
    }

    render() {
        return (
            <div>
                <h4 align="center">Aeroplane List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Capacity</th>
                            <th>Takeoff Effort Per Occupied Seat</th>
                            <th>Fuel Consumption Per Seat</th>
                            <th colSpan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        { this.tabRow() }
                    </tbody>
                </table>
            </div>
        );
    }
}