import React from "react";

function NoteEditor(props){
    return(
        <div>
            <div className="input-group input-group-lg">
                <span className="input-group-text" id="inputGroup-sizing-lg">Title</span>
                <input type="text" className="form-control" aria-label="Sizing example input"
                    aria-describedby="inputGroup-sizing-lg"/>
            </div>
            <div className="input-group mb-3">
                <span className="input-group-text" id="inputGroup-sizing-default">Note</span>
                <input type="text" className="form-control" aria-label="Sizing example input"
                    aria-describedby="inputGroup-sizing-default"/>
            </div>
        </div>);
}

export default NoteEditor;