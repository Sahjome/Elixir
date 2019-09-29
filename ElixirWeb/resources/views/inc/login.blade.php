<!-- <script src="//code.jquery.com/jquery.js"></script> -->
   
    <div class="modal fade" id="logInPopUp">
        <div class="modal-dialog">           
            <div class="modal-content">
                <div class="modal-header header-color" style="color:orangered">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- @if (session('error'))
                     <div class="alert alert-danger">
                        {{ session('error') }}
                    </div>
                @endif -->
                <div class="modal-body" id="model-bg-color">
                    <h5 class="font-weight-regular color title-position">SIGN IN</h5>
                    <form action={{'/login'}} method="GET" role="form" onsubmit="return checkForm(this)">
                       
                        <label for="Email">Email</label> 
                        <div class="input-group mb-3">       
                            <div class="input-group-prepend">
                                <span class="input-group-text rounded-0"><i class="fa fa-envelope"></i></span>
                            </div>
                            <input type="email" class="form-control rounded-0" placeholder="Email" name="entry" formcontrolname="Email" autocomplete="username" required autofocus>
                        </div>
                        <label for="Password">Password</label> 
                        <div class="input-group">   
                            <div class="input-group-prepend">
                                <span class="input-group-text rounded-0"><i class="fa fa-lock"></i></span>
                            </div>
                            <input type="password" class="form-control rounded-0" placeholder="Password" name="password" formcontrolname="password"  autocomplete="current-password" id="showPass" required>
                            <div class="input-group-append">
                                <span class="input-group-text rounded-0" id="bg-input-color"><i class="fa fa-eye-slash" id="eyeChange" onclick="passToggle()"></i></span>
                            </div>
                        </div>
                        {{-- <small id="warning-text" class="form-text mb-3 text-danger font-weight-bold d-none">Passwords must be a minimum of 8 characters, inclusive of alphanumeric and special characters.</small> --}}
                        <div class="checkbox mt-3">
                            <label><input type="checkbox"> Remember me</label>
                        </div>
                    <button class="btn btn-info mt-3" id="signin-button-clohea" type="submit" value="submit">SIGN IN</button>
                    <div class="forget-pass">
                        <a href="/forgetpassword">Forgot password?</a>
                    </div> 
                    <hr class="login-line"> 
                      
                    </form>                                          
                </div>
            </div>
        </div>
    </div>  

    {{-- <script>
        const re = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
        const warningText = document.querySelector('#warning-text');

        function checkPassword(password) {
            return re.test(password)
        };
        
        function checkForm(form) {
            if (!checkPassword(form.password.value)) {
                form.password.focus();
                warningText.classList.add('d-block')
                return false
            }
        };
        
    </script> --}}
