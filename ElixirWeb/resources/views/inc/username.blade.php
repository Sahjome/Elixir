
<div class="modal fade" id="myModalUsername">
    <div class="modal-dialog">           
        <div class="modal-content">
            <div class="modal-header" style="background: #c82333;">
                <h4 class="modal-title" id="myModalLabel" style="color:whitesmoke;">Enter Username</h4>
                <button type="button" class="close" style="border-color:blue; height:10px; color:blue" data-dismiss="modal" 
                aria-label="Close">&times;</button>
                
            </div>
            <div class="modal-body" id="model-bg-color">
                <form method="GET" role="form" onsubmit="return checkForm(this)" action="/reply">                
                    <div>
                        @csrf
                        <label class="form-label float-left">Username:</label>
                        <input name="username" class="form-control" required>
                    </div>
                    
                    <div class="modal-footer" id="modal-footer">
                        <button type="button" class="btn btn-info mt-2" style="padding-right:45px; padding-left:45px;" name="cancel" data-dismiss="modal" 
                        aria-label="Close" >Cancel</button>
                        <button type="submit" style="padding-right:25px; padding-left:25px;" class="btn btn-info mt-2">submit</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>  
