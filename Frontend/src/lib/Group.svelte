<script>
    import Slide from '$lib/Slide.svelte';

    let beingEdited = false;
    let beingCreated = false;
    let title = "Gott nytt år!";
    let creator = "bwidman";
    let lastEditedBy = "stensvad";
    let startDate = "2024-01-01 00:00";
    let endDate = "2024-12-31 23:59";
    let slides = [

    ];
</script>

<div class="group">
    <div class="group_header">
        <h1>{title}</h1>
        <p>Created by: {creator}</p>
        {#if lastEditedBy.length !== 0}
            <p>Last edited by: {lastEditedBy}</p>
        {/if}
        <div class = "group_header_button-container">
            <button class="group_edit-button">Edit</button>
            <button class="group_delete-button">Delete</button>
        </div>
    </div>
    <div class="group_slide-holder"> 
        {#each slides as slide}
            <Slide />
        {:else}
            <p>There are no slides yet</p>
            <Slide />
        {/each}
    </div>
    <div class="group_footer">
        <p>CIcon {startDate} PIcon {endDate}</p>
    </div>
</div>

<style>
    .group{
        margin: auto;
        width: 80%;
        background-color: bisque;
        border-radius: 20px;
        display: block;
        box-shadow: 5px 5px 5px gray;
    }
    .group_header {
        height: 50px;
        width: 100%;
        background-color: aquamarine;
        border-radius: 20px;
    }
    .group_header h1,
    .group_header p{
        display: inline;
        vertical-align: bottom;
    }
    .group_header_button-container{
        float: right;
    }
    .group_delete-button{
        
    }
    .group_slide-holder{
        margin-top: 10px;
        margin-bottom: 10px;
    }
    .group_footer {
        display: flex;
        height: 50px;
        width: 100%;
        background-color: aquamarine;
        border-radius: 20px;
        align-items: center;
    }
    .group_footer p{
       
    }
</style>