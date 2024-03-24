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
    export let slides = [1];

    const iconColorBlack = "#000000"
    const iconColorRed = "#E82305"
    const iconColorGreen = "#0FF71E"

    $: startDateTime = `${startDate} ${startTime}`;
    $: endDateTime = `${endDate} ${endTime}`;

    const clickedEdit = () => {
        state = "edit";
    };
    const clickedConfirm = () => {
        title = title.trim();
        if (title.length >= 3){
            state = "preview";
        } else {
            alert("Title too short");
        }
    };
    const clickedPublish = () => {
        title = title.trim();
        if (title.length >= 3){
            state = "preview";
        } else {
            alert("Title too short");
        }
    };
    const clickedAddSlide = () => {
        if (slides.length >= 10){
            alert("This collection already containt the maximum amount of 10 slides");
        } else {
            slides.push(1);
            slides = slides;
        }
    };

</script>

<div class="group">
    <!--HEADER-->
    <div class="group_header">
        {#if state === "create" || state === "edit"}
            <input type="text" maxlength="35" class="group_title-input" bind:value={title} placeholder="Title"/>
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
                <button class="group_edit-button" on:click={clickedEdit}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 24 24"><path fill={iconColorBlack} d="M16.293 3.293a1 1 0 0 1 1.414 0l3 3a1 1 0 0 1 0 1.414l-9 9A1 1 0 0 1 11 17H8a1 1 0 0 1-1-1v-3a1 1 0 0 1 .293-.707zM9 13.414V15h1.586l8-8L17 5.414zM3 7a2 2 0 0 1 2-2h5a1 1 0 1 1 0 2H5v12h12v-5a1 1 0 1 1 2 0v5a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/></svg>
                </button>
            {/if}
            {#if state === "edit"}
                <button class="group_slide-history-button">
                    <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill={iconColorBlack} fill-rule="evenodd" d="M4.806.665A8 8 0 1 1 .612 11.07a.75.75 0 1 1 1.385-.575A6.5 6.5 0 1 0 2.523 4.5H4.25a.75.75 0 0 1 0 1.5H0V1.75a.75.75 0 0 1 1.5 0v1.586A8 8 0 0 1 4.806.666ZM8 3a.75.75 0 0 1 .75.75v3.94l2.034 2.034a.75.75 0 1 1-1.06 1.06L7.47 8.53l-.22-.22V3.75A.75.75 0 0 1 8 3" clip-rule="evenodd"/></svg>
                </button>
                <button class="group_confirm-button" on:click={clickedConfirm}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="2.25em" height="2em" viewBox="0 0 1600 1280"><path fill={iconColorGreen} d="M1575 310q0 40-28 68l-724 724l-136 136q-28 28-68 28t-68-28l-136-136L53 740q-28-28-28-68t28-68l136-136q28-28 68-28t68 28l294 295l656-657q28-28 68-28t68 28l136 136q28 28 28 68"/></svg>
                </button>
            {/if}
            {#if state !== "restore"}
                <button class="group_delete-button">
                    <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill={iconColorRed} d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/></svg>
                </button>
            {/if}
        </div>
    </div>

    <!--MIDDLE-->
    {#if hidden == false || state === "create"}
        <div class="group_middle"> 
            <div class="group_slide-holder"> 
                {#each slides as slide}
                    <div class="group_slide"><Slide /></div>
                {:else}
                    <p>There are no slides yet</p>
                {/each}
            </div>
            {#if state === "create" || state === "edit"}
                <button class="group_add-slide-button" on:click={clickedAddSlide}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 1408 1408"><path fill={iconColorBlack} d="M1408 608v192q0 40-28 68t-68 28H896v416q0 40-28 68t-68 28H608q-40 0-68-28t-28-68V896H96q-40 0-68-28T0 800V608q0-40 28-68t68-28h416V96q0-40 28-68t68-28h192q40 0 68 28t28 68v416h416q40 0 68 28t28 68"/></svg>
                </button>
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

            <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill={iconColorBlack} fill-rule="evenodd" d="M10.159 10.72a.75.75 0 1 0 1.06 1.06l3.25-3.25L15 8l-.53-.53l-3.25-3.25a.75.75 0 0 0-1.061 1.06l1.97 1.97H1.75a.75.75 0 1 0 0 1.5h10.379z" clip-rule="evenodd"/></svg>
            {#if !neverExpire}
                <input type="date" bind:value={endDate}/>
                <input type="time" bind:value={endTime}/>
            {/if}

            <p>Never expire: </p>
            <input type="checkbox" class="group_checkbox" bind:checked={neverExpire}/>

            <div class="group_footer_right-container">
                <p>Only display this group: </p>
                <input type="checkbox" class="group_checkbox" bind:checked={priority}/>
                <p>Hide this group: </p>
                <input type="checkbox" class="group_checkbox" bind:checked={hidden}/>
            </div>
            
        {:else if state === "preview"}
            <p>
                <svg xmlns="http://www.w3.org/2000/svg" width="1.5em" height="1.5em" viewBox="0 0 24 24"><g fill="none" stroke={iconColorBlack} stroke-linecap="round" stroke-linejoin="round" stroke-width="2"><path d="M8 2v4m8-4v4"/><rect width="18" height="18" x="3" y="4" rx="2"/><path d="M3 10h18M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"/></g></svg> 
                {startDateTime} 
                <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill={iconColorBlack} fill-rule="evenodd" d="M10.159 10.72a.75.75 0 1 0 1.06 1.06l3.25-3.25L15 8l-.53-.53l-3.25-3.25a.75.75 0 0 0-1.061 1.06l1.97 1.97H1.75a.75.75 0 1 0 0 1.5h10.379z" clip-rule="evenodd"/></svg>
                <svg xmlns="http://www.w3.org/2000/svg" width="1.5em" height="1.5em" viewBox="0 0 24 24"><g fill="none" stroke={iconColorBlack} stroke-linecap="round" stroke-linejoin="round" stroke-width="2"><path d="M8 2v4m8-4v4"/><rect width="18" height="18" x="3" y="4" rx="2"/><path d="M3 10h18M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"/></g></svg> 
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
        margin-top: 50px;
        margin-bottom: 50px;
        width: 80%;
        background-color: #E5E5E5;
        border-radius: 20px;
        display: block;
        box-shadow: 2px 2px 5px gray;
    }
    .group_header {
        padding: 1em;
        height: 50px;
        width: auto;
    }
    .group_header h1,
    .group_header p,
    .group_footer p{
        display: inline;
        vertical-align: middle;
        font-weight: 600;
    }
    .group_header_right-container{
        float: right;
    }
    .group_slide-history-button{
        all: unset;
    }
    .group_confirm-button{
        all: unset;
    }
    .group_delete-button{
        all: unset;
    }
    .group_edit-button{
        all: unset;
    }
    .group_title-input{
        border: 0;
        height: 80%;
        border-radius: 0.4em;
        height: 2em;
        font-size: larger;
        text-align: center;
    }

    .group_middle{
        margin-top: 10px;
        margin-bottom: 10px;
        text-align: center;
    }
    .group_slide-holder{
       padding: 2em;
    }
    .group_slide{
        display: block;
        margin: auto;
        padding: 0.5em;
    }
    

    .group_add-slide-button{
        width: 80%;
        height: 3em;
        background-color: #66ff66;
        border: 1px solid rgba(8, 66, 15, 0.15);
        border-radius: 0.3em;
        font-size: larger;
    }

    .group_add-slide-button:hover{
        background-color: #2c974b;
    }

    .group_footer {
        padding-left: 1em;
        padding-right: 1em;
        height: 3em;
        width: auto;
        font-size: 1.2em;
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
        display: block;
        background-color: #66ff66;
        color: #fff;
        border: 1px solid rgba(8, 66, 15, 0.15);
        border-radius: 0.3em;

        box-sizing: border-box;
        font-size: 1.5em;
        font-weight: 600;
        line-height: 2.5em;

        margin-right: 2em;
        margin-left:auto;
        margin-top: 2em;
        margin-bottom: auto;
    }

    .group_publish-button:hover {
        background-color: #2c974b;
    }

    .group_checkbox{
        height: 2em;
        width: 2em;
    }
</style>