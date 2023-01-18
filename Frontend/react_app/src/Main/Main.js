import React from 'react';
import './Main.css'
import 'bootstrap/dist/css/bootstrap.min.css';

function Main(){
    return (
      <div className="container">
          <div className="row">
              <div className="col-sm">
                  <div className={"Elements-after-welcome-container"}>
                      <p className="Welcome-string">Welcome!</p>
                      <p className="Sentences-after-welcome">
                          This web-application give you possibility to save your life`s tasks
                      </p>
                      <div className="Vertical-line"/>
                      <p className="Sentences-after-welcome">
                          Even if you often forget something, you can save everything here and just see what you need to do!
                      </p>
                  </div>
              </div>
              <div className="col-sm">
                  <img src={require('../Images/logo.png')} className='Logo-image'/>
              </div>
          </div>
          <div className='row Container-for-button'>
              <button className="Button-for-login">Start an work with this application!</button>
          </div>
      </div>
    );
}

export default Main;