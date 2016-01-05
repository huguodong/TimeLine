package md5e44603b235f21ebfbb6b3d0f2dc433d5;


public class TimeLineModel
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Sample.TimeLineModel, Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TimeLineModel.class, __md_methods);
	}


	public TimeLineModel () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TimeLineModel.class)
			mono.android.TypeManager.Activate ("Sample.TimeLineModel, Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
