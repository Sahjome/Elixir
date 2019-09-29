<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateProfilesTable extends Migration
{
    /**		
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('profiles', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('Username');
            $table->string('Firstname');
            $table->string('Surname');
            $table->string('Othername')->nullable();
            $table->boolean('Sex');
            $table->string('Email');
            $table->DateTime('Grad')->nullable();
            $table->string('Password');
            $table->string('Committee')->nullable();
            $table->boolean('Status');
            $table->integer('Phone');
            $table->string('Address');
            $table->Date('DOB')->nullable();
            $table->string('Dept')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('profiles');
    }
}
