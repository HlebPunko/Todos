import React from 'react';
import './Main.css'
import 'bootstrap/dist/css/bootstrap.min.css';

function Main(){
    return (
      <div className="container-fluid">
          <div className="row">
              <div className="Custom-col col-12 col-lg-6 ">
                      <div className="Welcome-string">Welcome!</div>
                      <div className="Sentences-after-welcome">
                          This web-application give you possibility to save your life`s tasks
                      </div>
                      <div className="Vertical-line"/>
                      <div className="Sentences-after-welcome">
                          Even if you often forget something, you can save everything here and just see what you need to do!
                      </div>
              </div>
              <div className="Custom-col col-12 col-lg-6">
                  <div className='Welcome-string'>Todos</div>
                  <img src={require('../Images/logo.svg').default} className='Logo-image'/>
                  <div className='Sentences-after-welcome'>Now you will remember everything</div>
              </div>
          </div>
          <div className='Container-for-button'>
              <button className="Button-for-login">Start an work with this application!</button>
          </div>
      </div>
    );
}

export default Main;