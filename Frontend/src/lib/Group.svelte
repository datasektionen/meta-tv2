<script>
    import Slide from '$lib/Slide.svelte';

    export let state = "preview"; //preview, create, edit, restore
    export let title = "Title";
    export let creator = "bwidman";
    export let lastEditedBy = "";
    export let hidden = false;
    export let priority = false;
    export let neverExpire = false;
    export let startDate = (new Date()).toISOString().split('T')[0];
    export let startTime = (new Date()).getHours().toLocaleString(undefined,{minimumIntegerDigits: 2}) + ":" + (new Date()).getMinutes().toLocaleString(undefined,{minimumIntegerDigits: 2});
    export let endDate = (new Date()).toISOString().split('T')[0];
    export let endTime = (new Date()).getHours().toLocaleString(undefined,{minimumIntegerDigits: 2}) + ":" + (new Date()).getMinutes().toLocaleString(undefined,{minimumIntegerDigits: 2});
    export let archivedDate = "";
    export let slides = [];

    $: startDateTime = `${startDate} ${startTime}`;
    $: endDateTime = `${endDate} ${endTime}`;

    const clickedEdit = () => {
        state = "edit";
    };
    const clickedConfirm = () => {
        state = "preview";
    };
    const clickedPublish = () => {
        state = "preview";
    };

</script>

<div class="group">
    <!--HEADER-->
    <div class="group_header">
        {#if state === "create" || state === "edit"}
            <input type="text" class="group_title-input" bind:value={title} placeholder="Title"/>
        {:else if state === "preview" || state === "restore"}
            <h1>{title}</h1>
        {/if}
    
        <p class="group_header_gray-text">Created by: {creator}</p>
        {#if lastEditedBy.length !== 0}
            <p class="group_header_gray-text">Last edited by: {lastEditedBy}</p>
        {/if}
        <div class = "group_header_right-container">
            {#if priority}
                <p>Priority</p>
            {/if}
            {#if hidden == false && state === "preview"}
                <button class="group_edit-button" on:click={clickedEdit}>Edit</button>
            {/if}
            {#if state === "edit"}
                <button class="group_slide-history-button">History</button>
                <button class="group_confirm-button" on:click={clickedConfirm}>Confirm</button>
            {/if}
            <button class="group_delete-button">Delete</button>
        </div>
    </div>

    <!--MIDDLE-->
    {#if hidden == false || state === "create"}
        <div class="group_slide-holder"> 
            {#each slides as slide}
                slide
            {:else}
                <p>There are no slides yet</p>
            {/each}
            {#if state === "create" || state === "edit"}
                <button class="group_add-slide-button">+</button>
            {/if}
        </div>
    {:else}
        <p class="group_footer_gray-text">This content has been hidden</p>
    {/if}

    <!--FOOTER-->
    <div class="group_footer">
        {#if state === "create" || state === "edit"}
            <input type="date" bind:value={startDate}/>
            <input type="time" bind:value={startTime}/>            

            <p>--></p>
            {#if !neverExpire}
                <input type="date" bind:value={endDate}/>
                <input type="time" bind:value={endTime}/>
            {/if}

            <p>Never expire: </p>
            <input type="checkbox" bind:checked={neverExpire}/>

            <div class="group_footer_right-container">
                <p>Only display this group: </p>
                <input type="checkbox" bind:checked={priority}/>
                <button>Hide content</button>
            </div>
            
        {:else if state === "preview"}
            <p>CIcon {startDateTime} ---> 
                {#if neverExpire}
                    Forever
                {:else}
                    {endDateTime}
                {/if}
            </p>
        {:else if state === "restore"}
            <p>Archived: {archivedDate}</p>
        {/if}
        
    </div>
    {#if state === "create"}
        <button class="group_publish-button" on:click={clickedPublish}>Publish</button>
    {/if}
</div>

<style>
    .group{
        margin: auto;
        margin-bottom: 50px;
        width: 80%;
        background-color: #E5E5E5;
        border-radius: 20px;
        display: block;
        box-shadow: 2px 2px 5px gray;
    }
    .group_header {
        padding: 20px;
        height: 50px;
        width: auto;
    }
    .group_header h1,
    .group_header p,
    .group_footer p{
        display: inline;
        vertical-align: bottom;
    }
    .group_header_right-container{
        float: right;
    }
    .group_delete-button{
        
    }
    .group_title-input{
        border: 0;
        height: 80%;
        border-radius: 10px;
        font-size: larger;
        text-align: center;
    }

    .group_slide-holder{
        margin-top: 10px;
        margin-bottom: 10px;
        text-align: center;
    }
    .group_add-slide-button{
        width: 80%;
        height: 40px;
        background-color: #66ff66;
        border-width: 1px;
        border-radius: 10px;
        font-size: larger;
    }

    .group_footer {
        padding: 20px;
        height: 50px;
        width: auto;
    }

    .group_header_gray-text,
    .group_footer_gray-text{
        color: #686868;
    }
    .group_header_gray-text{
        margin-right: 20px;
    }
    .group_footer_gray-text{
        text-align: center;
    }
    .group_footer_right-container{
        float: right;
    }

    .group_publish-button{
        padding: 10px;
        display: block;
        background-color: #66ff66;
        margin-right: 0;
        margin-left:auto;
        margin-top: 0;
        margin-bottom: auto;
    }
</style>