
    <div class="modal fade" id="myModalQuestion">
            <div class="modal-dialog">           
                <div class="modal-content">
                    <div class="modal-header" style="background: #c82333;">
                        <h4 class="modal-title" id="myModalLabel" style="color:whitesmoke;">Delete</h4>
                        <button type="button" class="close" style="border-color:blue; height:10px; color:blue" data-dismiss="modal" 
                        aria-label="Close">&times;</button>
                        
                    </div>
                    <div class="modal-body" id="model-bg-color">
                            <div>
                                <h5 class="font-weight-regular color title-position">Confirm Delete</h5>
                                Are you Sure you want to delete?
                            </div>
                            
                            <div class="modal-footer" id="modal-footer">
                                <button type="button" class="btn btn-info mt-2" style="padding-right:45px; padding-left:45px;" name="cancel" data-dismiss="modal" 
                                aria-label="Close" >No</button>
                                <form class="col-4" method="POST" role="form" onsubmit="return checkForm(this)" action={{$url.$id}}>
                                    @csrf
                                    <input type="hidden" _method="DELETE">
                                    <button type="submit" style="padding-right:25px; padding-left:25px;" class="btn btn-info mt-2">delete</button>
                                </form>
                            </div>
                    </div>
                </div>
            </div>
        </div>  