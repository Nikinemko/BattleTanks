import React, { Component } from 'react';
import { connect } from 'react-redux';
import Home from '../components/home';
import { get_tanks } from '../actions/tanks';
import { get_maps } from '../actions/maps';
import { createGame } from '../actions/game';
import Spinner from '../components/spinner';
 
class HomeWrapper extends Component {

    onSubmit = val => {
        this.props.create_game({
            TankId: val.tankId,
            MapId: val.mapId,
            Online: parseInt(val.online)
       });      
    }
    
    componentDidMount(){
        this.props.get_tanks();
        this.props.get_maps();
    }

    render() {
        const { isSuccess, isPending } = this.props.tanks;
        const { maps } = this.props;
        const content = isSuccess & maps.isSuccess ? <Home onSubmit={this.onSubmit} onCompSubmit={this.ComputerGame}/> : null;
        const spinner = isPending & maps.isPending ? <Spinner/> : null;
        return <>
            {spinner || content}    
        </>
    }
}

const mapStateToProps = state => {
    return {
        user: state.user,
        tanks: state.tanks,
        maps: state.maps
    }
};

const mapDispatchToProps = dispatch => {
  return {
    get_tanks: () => dispatch(get_tanks()),
    get_maps: () => dispatch(get_maps()),
    create_game: (data) => dispatch(createGame(data))
  };
};
export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HomeWrapper);