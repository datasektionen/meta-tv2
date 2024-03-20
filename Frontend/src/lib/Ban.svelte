<!--
    TODO: 
    1. Kontrollera att tillagda mailaddresser exister/stämmer
    2. Snyggare knappar
-->    
<script>
    export let bans = []
    export let account = ""

    function removeName(index) {
        bans = [...bans.slice(0, index), ...bans.slice(index+1)];
    }

    function addName() {
        if(account != "") {
            bans = [...bans, account];
            account = "";
        }
    }
    
    function handleEnter(e) {
        if(e.key === 'Enter') addName();
    }
</script>

<div class = "ban_holder">
    <div class = "ban_title">
        <h3>Banned Users</h3>
    </div>
    <div class = "ban_interface">
        <input bind:value={account} placeholder="enter new account" on:keydown={(e)=>{handleEnter(e)}}/>
        <button on:click={addName}>Add</button>
    </div>
    <div class = "ban_list">
        {#each bans as ban, index}
            <div class = "ban_row">
                {bans[index]}
                <button class="ban_remove" 
                    on:click={()=>removeName(index)}>X</button>
                <br>
            </div>
        {/each}
    </div>
</div>


<style>
    .ban_title{
        height: 25px;
        left: 25px;
        text-align: center;
    }
    .ban_interface{
        padding: 10px;
    }
    .ban_list{
        height: 400px;
        width: 250px;
        padding: 10px;
        background-color: #E5E5E5;
        border-radius: 10px;
        display: block;
        box-shadow: 2px 2px 5px gray;
        overflow: auto;
    }
    .ban_remove{
        position: absolute;
        left: 220px;
        border: none;
        background: none;
        color: #FF0000;
        text-align: center;
    }
    .ban_holder{
        position: absolute;   
        top: 100px;
        left: 25px;
    }
    .ban_row{
        position: relative;
    }
</style>
