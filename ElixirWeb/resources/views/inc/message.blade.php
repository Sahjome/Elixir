@if (count($errors)>0)
    @foreach ($errors->all() as $error)
        <div class="alert alert-danger">
            <button type="button" class="close" data-dismiss="alert">X</button>
            <strong>{{$error}}</strong>
        </div>
    @endforeach
    
    @if (Session('success'))
        <div class="alert alert-success alert-block">
            <button type="button" class="close" data-dismiss="alert">X</button>
            <strong>{{Session('success')}}</strong>
        </div>
    @endif
    
    @if (Session('error'))
        <div class="alert alert-danger alert-block">
            <button type="button" class="close" data-dismiss="alert">X</button>
            <strong>{{Session('error')}}</strong>
        </div>
    @endif
@endif