    <form action="#" method="post" name="myForm" id="myForm">
        <fieldset>

            <legend>Actor Information</legend>

            <label for="fName">First Name: </label>
            <input type="text" name="fName" id="fName"><br/>

            <label for="lName">Last Name: </label>
            <input type="text" name="lName" id="lName"><br/>

            Birthday:
            <select name="birthMonth" id="birthMonth">
                <option selected>Month</option>
                <option value="1">January</option>
                <option value="2">February</option>
                <option value="3">March</option>
                <option value="4">April</option>
                <option value="5">May</option>
                <option value="6">June</option>
                <option value="7">July</option>
                <option value="8">August</option>
                <option value="9">September</option>
                <option value="10">October</option>
                <option value="11">November</option>
                <option value="12">December</option>
            </select>

            <select name="birthYear" id="birthYear"></select>

            <select name="birthDay" id="birthDay">
                <option selected>Day</option>
            </select><br/>

            Gender: <input type="radio" name="gender" value="male" id="male"/> Male
            <input type="radio" name="gender" value="female" id="female"/> Female<br/>

            Genres: <br/>
            <input type="checkbox" name="actionGenre" id="genres" value="true" /> Action <br/>
            <input type="checkbox" name="comedyGenre" id="genres" value="true" /> Comedy <br/>
            <input type="checkbox" name="dramaGenre" id="genres" value="true" /> Drama <br/>
            <input type="checkbox" name="sciFiGenre" id="genres" value="true" /> Science Fiction <br/>

            <input type="submit" name="submit" id="submit" value="Add"/>
        </fieldset>
    </form>



