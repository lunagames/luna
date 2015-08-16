using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (LunaCharacterController))]
	public class LunaUserControl : MonoBehaviour
    {
		private LunaCharacterController m_Character;
        public bool m_Jump;
		public bool m_Ability;
		public float h;




        private void Awake()
        {
			m_Character = GetComponent<LunaCharacterController>();
        }


        private void Update()
        {

			#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("xbox button a");
		     }
			if (!m_Ability)
			{
				// Read the jump input in Update so button presses aren't missed.
				m_Ability = CrossPlatformInputManager.GetButtonDown("xbox button b");
			}
			#endif

        }




        private void FixedUpdate()
        {
            // Read the inputs.

			//Works for keyboards and joysticks
			#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
			h = CrossPlatformInputManager.GetAxis("Horizontal");
			// Pass all parameters to the character control script.
			m_Character.Move (h);
			m_Character.Jump (m_Jump);
			m_Jump = false;
			m_Character.Ability (m_Ability);
			m_Ability = false;
			#else
			m_Character.Move (h);
			#endif				

            
        }

		public void leftbuttonpress()
		{
			h = -1;
		}

		public void rightbuttonpress()
		{
			h = 1;
		}

		public void buttonrelease()
		{
			h = 0;
		}


    }
}
