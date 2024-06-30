<script>
    export let numberOfScreens = 3;

    function saveChange() {
        console.log("Update number of screens")
    }
</script>

<div class = "setting_holder">
    <div class = "setting_title">
        <h3>Number of TV's</h3>
    </div>
    <div class = "setting_interface">
        <input type="number" size="5" bind:value={numberOfScreens} min="0" />
        <button on:click={saveChange}>Save</button>
    </div>
</div>


<style>
    .setting_holder{
        position: absolute;   
        top: 100px;
        left: 350px;
    }
    .setting_title{
        height: 25px;
        left: 25px;
        text-align: center;
    }
    .setting_interface{
        position: absolute;   
        padding: 10px;
        left: 17px;
    }
</style>
