
<div class="container">
    @if (!empty($error))
        <div class="alert alert-danger">
            <button type="button" class="close" data-dismiss="alert">X</button>
            <strong>{{$error}}</strong>
        </div>
    
    @elseif (!empty($success))
        <div class="alert alert-success alert-block">
            <button type="button" class="close" data-dismiss="alert">X</button>
            <strong>{{$success}}</strong>
        </div>
    @else
    
    @endif
</div>

