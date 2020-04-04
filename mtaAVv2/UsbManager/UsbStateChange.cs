﻿//************************************************************************************************
// Copyright © 2017 Ladin Corp. Contact: noi.nguyen@lqdtu.edu.vn. All Rights Reserved.
//
//************************************************************************************************

namespace Ladin.UsbManager
{
    /// <summary>
	/// Specifies the various state changes for USB disk devices.
	/// </summary>

	public enum UsbStateChange
	{

		/// <summary>
		/// A device has been added and is now available.
		/// </summary>

		Added,


		/// <summary>
		/// A device is about to be removed;
		/// allows consumers to intercept and deny the action.
		/// </summary>

		Removing,


		/// <summary>
		/// A device has been removed and is no longer available.
		/// </summary>

		Removed
	}
}