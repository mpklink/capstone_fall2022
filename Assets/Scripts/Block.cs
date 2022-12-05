using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    public GameObject block;
    public GameObject player;


    static public List<GameObject> blocks_upper_left = new();
    static public List<GameObject> blocks_lower_left = new();
    static public List<GameObject> blocks_upper_right = new();
    static public List<GameObject> blocks_lower_right = new();
    static public List<GameObject> blocks_upper_row = new();
    

    public int BlockNum = 0;
    public int b_num;

    public List<int> nums = new();
    public Building[] builds;

    // Booleans for creation of blocks
    public bool init = true;

    // New wall coords for index: 0 -> x, 1 ->y , 2-> z
    public List<float> pos = new();

    // Create constante X and Z positions.
    int const_posX = 999;
    int neg_const_posX = -999;
    int const_posZ = 472;
    int neg_const_posZ = -420;


    /*
     *  VERSION 2 ADDED
     */

    public bool[,] grid_pos = new bool[9, 8];
    public int rows = 9;
    public int cols = 8;

    public Dictionary<(int i, int j), GameObject> grid_dict = new();

    public float pla_curr_x;
    public float pla_curr_z;

    public float block_curr_x;
    public float block_curr_z;

    public float current_pos_x;
    public float current_pos_z;
    public float total_curr;

    public int updt_i;
    public int updt_j;

    // Use this for initialization
    void Start()
    {

        // Get reference to player for positioning
        player = GameObject.Find("Player");
        //Get first block_number
        b_num = block.GetComponentInChildren<Building>().BlockNum;
        nums.Add(b_num);


        // Init the grid with false values -> No block created
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid_pos[i, j] = false;
            }
        }

        // Init central block (4,3)
        grid_pos[4, 3] = true;
        // Add your initial block to the dict
        grid_dict.Add((4, 3), block);

        /*
         * Once a new GO wants to be created, the dictionary will need to be check for:
         * i+1,j (DOWN)
         * i-j,j (UP)
         * i,j+1 (RIGHT)
         * i,j-1 (LEFT)
         * i+1,j+1 (R.DOWN)
         * i-1,j-1 (L.UP)
         * i+1,j-1 (L.DOWN)
         * i-1,j+1 (R.UP)
         * 
         * IF those values (i,j) are true in the grid -> DO NOT create
         *  - Get from dictionary the values of key (i,j) returns GO
         *  - Get x and z position of that GO
         *  - Compare relative distance with player (Manhattan (?), x and z (?))
         *  - Set a max distance (Try values), if distance max than that, destroy GameObject.
         *  - Delete that (i,j) key GO destroyed from dict
         *  - Set current closer block -> min distance on x and z to the player
         *  - For that block, create on all 8 directions, check if grid for tha dir is false, then create.
         * IF those values (i,j) are false -> CAN create
         */

        Create_inital_blocks();
    }
    
        


    public void Create_inital_blocks()
    {
        // Create Right
        Vector3 pos_right = new Vector3(const_posX, 0, 26);
        GameObject right_block = Instantiate(block, pos_right, Quaternion.identity);
        Set_block_num(right_block, 4,4);
        grid_pos[4, 4] = true;
        grid_dict.Add((4, 4), right_block);

        // Create Left
        Vector3 pos_left = new Vector3(neg_const_posX, 0, 26);
        GameObject left_block = Instantiate(block, pos_left, Quaternion.identity);
        Set_block_num(left_block,4,2);
        grid_pos[4, 2] = true;
        grid_dict.Add((4, 2), left_block);

        // Create Down
        Vector3 pos_low = new Vector3(0, 0, neg_const_posZ);
        GameObject lower_block = Instantiate(block, pos_low, Quaternion.identity);
        Set_block_num(lower_block,5,3);
        grid_pos[5, 3] = true;
        grid_dict.Add((5, 3), lower_block);

        // Create Up
        Vector3 pos_up = new Vector3(0, 0, const_posZ);
        GameObject upper_block = Instantiate(block, pos_up, Quaternion.identity);
        Set_block_num(upper_block, 3,3);
        grid_pos[3, 3] = true;
        grid_dict.Add((3, 3), upper_block);

        // Create Right UP
        Vector3 pos_right_up = new Vector3(const_posX, 0, const_posZ);
        GameObject right_up_block = Instantiate(block, pos_right_up, Quaternion.identity);
        Set_block_num(right_up_block,3,4);
        grid_pos[3, 4] = true;
        grid_dict.Add((3, 4), right_up_block);

        // Create Right DOWN
        Vector3 pos_right_down = new Vector3(const_posX, 0, neg_const_posZ);
        GameObject right_down_block = Instantiate(block, pos_right_down, Quaternion.identity);
        Set_block_num(right_down_block,5,4);
        grid_pos[5, 4] = true;
        grid_dict.Add((5, 4), right_down_block);

        // Create Left UP
        Vector3 pos_left_up = new Vector3(neg_const_posX, 0, const_posZ);
        GameObject left_up_block = Instantiate(block, pos_left_up, Quaternion.identity);
        Set_block_num(left_up_block,3,2);
        grid_pos[3, 2] = true;
        grid_dict.Add((3, 2), left_up_block);

        // Create Left DOWN
        Vector3 pos_left_down = new Vector3(neg_const_posX, 0, neg_const_posZ);
        GameObject left_down_block = Instantiate(block, pos_left_down, Quaternion.identity);
        Set_block_num(left_down_block,5,2);
        grid_pos[5, 2] = true;
        grid_dict.Add((5, 2), left_down_block);
    }



    IEnumerator CheckPosition()
    {
        // Wait for checking
        yield return new WaitForSeconds(9);

        // Get current player position
        pla_curr_x = player.transform.position.x;
        pla_curr_z = player.transform.position.z;

        // Iterate throught the values in dict
        float manhat_dist;
        float min_dist = 50000;

        GameObject curr_check_block;

        // Check for grid positions to get closest new block.
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                
                // If block instantiated for that pos, get the block game object
                if (grid_pos[i, j] == true)
                {
              
                    // Retrieve GameObject Block realted to that (i,j) grid position
                    curr_check_block = grid_dict[(i, j)];
                    block_curr_x = curr_check_block.transform.position.x;
                    block_curr_z = curr_check_block.transform.position.z;

                    // Difference between where player is, and where the current TRUE block is
                    current_pos_x = Mathf.Abs(pla_curr_x - block_curr_x);
                    current_pos_z = Mathf.Abs(pla_curr_z - block_curr_z);

                    // Distance between Player and center of block.
                    manhat_dist = Mathf.Sqrt(current_pos_x * current_pos_x + current_pos_z * current_pos_z);

                    // Destroy that block from the currently created TRUE blocks
                    if (manhat_dist > 1400)
                    {
                        DestroyImmediate(curr_check_block);
                        grid_pos[i, j] = false;
                        grid_dict.Remove((i, j));
                    }

                    // Update what from this (i,j) iter the closest block is
                    if(manhat_dist < min_dist)
                    {
                        min_dist = manhat_dist;
                        updt_i = i;
                        updt_j = j;
                    }
                }
            }
        }

        // Check where on the 4 COORD blocks the player is
        /*
         * +x, +z (UP RIGHT)
         * -x, +z (UP LEFT)
         * +x, -z (DOWN RIGHT)
         * -x, -z (DOWN LEFT)
         */

        //check up, if missing recreate
        /* 
         * i + 1, j     (DOWN)
         * i - 1, j     (UP)
         * i    , j + 1 (RIGHT)
         * i    , j - 1 (LEFT)
         * i + 1, j + 1 (R.DOWN)
         * i - 1, j - 1 (L.UP)
         * i + 1, j - 1 (L.DOWN)
         * i - 1, j + 1 (R.UP)
         */

        //Debug.Log("The closest block is " + updt_i + "," + updt_j);

        if (pla_curr_x >= 0 && pla_curr_z >= 0) // +x, +z(UP RIGHT)
        {
            // Checks up
            Check_block_created(updt_i, updt_j, -1, 0, 0, const_posZ - 26);

            // Checks right
            Check_block_created(updt_i, updt_j, 0, +1, const_posX, 0);

            // Checks up right
            Check_block_created(updt_i, updt_j, -1, +1, const_posX, const_posZ - 26);

            // Checks low right
            Check_block_created(updt_i, updt_j, +1, +1, const_posX, neg_const_posZ);

        }
        else if (pla_curr_x < 0 && pla_curr_z >= 0) // -x, +z (UP LEFT)
        {
            // Checks up
            Check_block_created(updt_i, updt_j, -1, 0, 0, const_posZ - 26);

            // Checks up left
            Check_block_created(updt_i, updt_j, -1, -1, neg_const_posX, const_posZ - 26);

            // Checks left
            Check_block_created(updt_i, updt_j, 0, -1, neg_const_posX, 0);

            // Checks low left
            Check_block_created(updt_i, updt_j, +1, -1, neg_const_posX, neg_const_posZ);
        }
        else if (pla_curr_z < 0 && pla_curr_x >= 0) // +x, -z (DOWN RIGHT)
        {
            //Checks low
            Check_block_created(updt_i, updt_j, +1, 0, 0, neg_const_posZ);

            // Checks right
            Check_block_created(updt_i, updt_j, 0, +1, const_posX, 0);

            // Checks low right
            Check_block_created(updt_i, updt_j, +1, +1, const_posX, neg_const_posZ);

            // Checks low left
            Check_block_created(updt_i, updt_j, +1, -1, neg_const_posX, neg_const_posZ);
        }
        else if (pla_curr_z < 0 && pla_curr_x < 0) // -x, -z (DOWN LEFT)
        {
            // Checks low
            Check_block_created(updt_i, updt_j, +1, 0, 0, neg_const_posZ);

            // Checks left
            Check_block_created(updt_i, updt_j, 0, -1, neg_const_posX, 0);

            // Checks low left
            Check_block_created(updt_i, updt_j, +1, -1, neg_const_posX, neg_const_posZ);

            // Checks low right
            Check_block_created(updt_i, updt_j, +1, +1, const_posX, neg_const_posZ);
        }

    }

    public void Check_block_created(int i, int j, int vert, int hor, int x_const, int z_const)
    {

        int cr_i = i + vert;
        int cr_j = j + hor;

        // Check that the blocks to create are not outside the terrain boundaries [9,8]
        if (cr_i > 8 || cr_j > 7)
        {
            Debug.Log("Outside bounds");
            return;
        }

        if(cr_i < 0 || cr_j < 0)
        {
            Debug.Log("Outside bounds");
            return;
        }

        // Create new blocks
        GameObject curr_check_block;

        // If the checked new block is false (not yet created) with respect to the current block
        if (grid_pos[cr_i, cr_j] == false)
        {
            // Get that current block 
            curr_check_block = grid_dict[(i, j)];
            block_curr_x = curr_check_block.transform.position.x;
            block_curr_z = curr_check_block.transform.position.z;

            // Instantiate the block. Set to true in the array, and add to dict
            Vector3 position = new Vector3(block_curr_x + x_const, 0, block_curr_z + z_const);
            GameObject inst_obj = Instantiate(block, position, Quaternion.identity);
            Set_block_num(inst_obj, i, j);
            grid_pos[cr_i, cr_j] = true;
            grid_dict.Add((cr_i, cr_j), inst_obj);
        }
    }

    // Update is called once per frame
    // Here we want them to dissapear, and to appear on range of visibility
    void Update()
    {

        StartCoroutine(CheckPosition());

    }

    // Set new Block Numbers for newly generated blocks
    private void Set_block_num(GameObject parent, int i, int j)
    {
        // Assign block number based on grid position
        int block_num = (i+1) * (j+1);

        if(block_num > 69)
        {
            block_num -= 69;
        }

        // Assign to all buildings in that block.
        builds = parent.GetComponentsInChildren<Building>();
        foreach (Building building in builds)
        {
            building.BlockNum = block_num;
            //Debug.Log("All new blocks are num " + yourScript.BlockNum);
        }

    }

    //// Set new Block Numbers for newly generated blocks
    //private void set_block_num(GameObject parent)
    //{
    //    // Get last block number assigned
    //    int last;
    //    int new_b;
    //    last = nums[^1];

    //    if (last == 69)
    //    {
    //        // set bool no more creation -> True;
    //        return;
    //    }

    //    // Increment and set for each building the BlockNum associated.
    //    new_b = last + 1;
    //    nums.Add(new_b);

    //    builds = parent.GetComponentsInChildren<Building>();
    //    foreach (Building building in builds)
    //    {
    //        building.BlockNum = new_b;
    //        //Debug.Log("All new blocks are num " + yourScript.BlockNum);
    //    }

    //}

}
